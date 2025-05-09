using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechProcessSupportSys.Dtos.Operation;
using TechProcessSupportSys.Dtos.TechProcess;
using TechProcessSupportSys.Extentions;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IAutomapper automapper;
        private readonly IOperationRepository operationRepo;
        private readonly UserManager<User> userManager;

        public OperationController(IAutomapper automapper, IOperationRepository operationRepo, UserManager<User> userManager)
        {
            this.automapper = automapper;
            this.operationRepo = operationRepo;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetOperation([FromQuery] OperationQueryObject query)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var id = User.IsInRole("Admin") ? null : user!.Id;

            var operations = await operationRepo.GetAllAsync(id, query);

            var operationsDto = operations.Select(o => automapper.Map<OperationDto, Operation>(o)).ToList();

            return Ok(operationsDto);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var userId = User.IsInRole("Admin") ? null : user!.Id;

            var operation = await operationRepo.GetByIdAsync(userId, id);

            if (operation == null) return NotFound();

            return Ok(automapper.Map<OperationDto, Operation>(operation));
        }

        [HttpPost("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] int id, [FromBody] CreateOperationDto createOperationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var operation = automapper.Map<Operation, CreateOperationDto>(createOperationDto);
                operation.ProcessId = id;

                await operationRepo.CreateAsync(operation);

                return CreatedAtAction(nameof(GetById), new { id = operation.Id }, automapper.Map<OperationDto, Operation>(operation));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOperationDto updateOperationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var username = User.GetUsername();
                var user = await userManager.FindByNameAsync(username!);
                var userId = User.IsInRole("Admin") ? null : user!.Id;

                var operation = automapper.Map<Operation, UpdateOperationDto>(updateOperationDto);

                var updated = await operationRepo.UpdateAsync(userId, id, operation);

                if (updated == null) return NotFound();
                
                 return Ok(automapper.Map<OperationDto, Operation>(updated));
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
            var userId = User.IsInRole("Admin") ? null : user!.Id;

            var deleted = await operationRepo.DeleteAsync(userId, id);

            if (deleted == null) return NotFound();

            return NoContent();
        }
    }
}