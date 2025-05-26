using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechProcessSupportSys.Dtos.Operation;
using TechProcessSupportSys.Dtos.Transition;
using TechProcessSupportSys.Extentions;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransitionController : ControllerBase
    {
        private readonly IAutomapper automapper;
        private readonly ITransitionRepository transitionRepo;
        private readonly UserManager<User> userManager;

        public TransitionController(IAutomapper automapper, ITransitionRepository transitionRepo, UserManager<User> userManager)
        {
            this.automapper = automapper;
            this.transitionRepo = transitionRepo;
            this.userManager = userManager;
        }

        [HttpGet("{operationId:int}")]
        public async Task<IActionResult> GetTransitions([FromRoute] int operationId)
        {
            string userId = "";
            bool isAdmin = false;
            var username = User.GetUsername();
            if (username != null)
            {
                var user = await userManager.FindByNameAsync(username);
                userId = user!.Id;
                isAdmin = await userManager.IsInRoleAsync(user, "Admin");
            }

            var transitions = await transitionRepo.GetAllAsync(operationId, isAdmin, userId);

            if (transitions == null) return NotFound();

            var transitionsDto = transitions.Select(o => automapper.Map<TransitionDto, Transition>(o)).ToList();

            return Ok(transitionsDto);
        }

        [HttpGet("read-transition/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            string userId = "";
            bool isAdmin = false;
            var username = User.GetUsername();
            if (username != null)
            {
                var user = await userManager.FindByNameAsync(username);
                userId = user!.Id;
                isAdmin = await userManager.IsInRoleAsync(user, "Admin");
            }

            var transition = await transitionRepo.GetByIdAsync(isAdmin, userId, id);

            if (transition == null) return NotFound();

            return Ok(automapper.Map<TransitionExtendedDto, Transition>(transition));
        }

        [HttpPost("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] int id, [FromBody] CreateTransitionDto createTransitionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await transitionRepo.IsStepOrderDublicate(id, createTransitionDto.StepOrder)) return BadRequest("Такой номер перехода уже есть");

                var username = User.GetUsername();
                var user = await userManager.FindByNameAsync(username);

                var userId = await transitionRepo.GetUserId(id);
                if (userId == null) return NotFound();
                if (userId != user.Id) return Forbid();

                if (createTransitionDto.StepOrder == null)
                {
                    var result = transitionRepo.CreateStepOrder(id);
                    if (result == null) return BadRequest("Превышено максимальное количество переходов(60)");
                    createTransitionDto.StepOrder = result;
                }

                var transition = automapper.Map<Transition, CreateTransitionDto>(createTransitionDto);
                transition.OperationId = id;
                transition.Author = username;
                transition.UpdatedAt = DateTime.UtcNow;
                transition.UpdatedBy = username;

                await transitionRepo.CreateAsync(transition);

                return CreatedAtAction(nameof(GetById), new { id = transition.Id }, automapper.Map<TransitionOsnDto, Transition>(transition));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTransitionDto updateTransitionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await transitionRepo.IsStepOrderDublicateByTransitionId(id, updateTransitionDto.StepOrder)) return BadRequest("Такой номер перехода уже есть");

                var username = User.GetUsername();
                var user = await userManager.FindByNameAsync(username!);
                var userId = await userManager.IsInRoleAsync(user, "Admin") ? null : user!.Id;

                var transition = automapper.Map<Transition, UpdateTransitionDto>(updateTransitionDto);
                transition.UpdatedAt = DateTime.UtcNow;
                transition.UpdatedBy = username;

                var updated = await transitionRepo.UpdateAsync(userId, id, transition);

                if (updated == null) return NotFound();

                return Ok(automapper.Map<TransitionOsnDto, Transition>(updated));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var userId = await userManager.IsInRoleAsync(user, "Admin") ? null : user!.Id;

            var deleted = await transitionRepo.DeleteAsync(userId, id);

            if (deleted == null) return NotFound();

            return NoContent();
        }
    }
}