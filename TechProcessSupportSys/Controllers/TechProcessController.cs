using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechProcessSupportSys.Dtos.TechProcess;
using TechProcessSupportSys.Dtos.Tool;
using TechProcessSupportSys.Extentions;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechProcessController : ControllerBase
    {
        private readonly IAutomapper automapper;
        private readonly ITechProcessRepository techRepo;
        private readonly UserManager<User> userManager;

        public TechProcessController(IAutomapper automapper, ITechProcessRepository techRepo, UserManager<User> userManager)
        {
            this.automapper = automapper;
            this.techRepo = techRepo;
            this.userManager = userManager;
        }

        [HttpGet("all")]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] AllQueryObject query)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var id = User.IsInRole("Admin") ? null : user!.Id;

            var processes = await techRepo.GetAllAsync(id, query);

            var processesDto = processes.Select(p => automapper.Map<AllDto,CreateAllDto>(p)).ToList();

            return Ok(processesDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetProcesses([FromQuery] TechProcessQueryObject query)
        {
            string userId = "";
            bool isAdmin = false;
            var username = User.GetUsername();
            if (username != null)
            {
                var user = await userManager.FindByNameAsync(username);
                userId = user!.Id;
                isAdmin = User.IsInRole("Admin") ? true : false;
            }

            var processes = await techRepo.GetProcessesAsync(isAdmin, userId, query);

            var processesDto = processes.Select(p => automapper.Map<TechProcessDto, TechProcess>(p)).ToList();

            return Ok(processesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            string userId = "";
            bool isAdmin = false;
            var username = User.GetUsername();
            if (username != null)
            {
                var user = await userManager.FindByNameAsync(username);
                userId = user!.Id;
                isAdmin = User.IsInRole("Admin") ? true : false;
            }

            var process = await techRepo.GetByIdAsync(isAdmin, userId, id);

            if (process == null) return NotFound();

            return Ok(automapper.Map<TechProcessDto, TechProcess>(process));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateTechProcessDto createTechProcessDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var username = User.GetUsername();
                var user = await userManager.FindByNameAsync(username!);

                var process = automapper.Map<TechProcess, CreateTechProcessDto>(createTechProcessDto);
                process.UserId = user!.Id;

                await techRepo.CreateAsync(process);

                return CreatedAtAction(nameof(GetById), new { id = process.Id }, automapper.Map<TechProcessDto, TechProcess>(process));
            }
            catch (DbUpdateException ex)
            {
                var uniqueEx = ex.IsUniqueKeyException();
                if (uniqueEx is not null) return uniqueEx;
                return StatusCode(500, ex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTechProcessDto updateTechProcessDto)
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

                var process = automapper.Map<TechProcess, UpdateTechProcessDto>(updateTechProcessDto);

                var updated = await techRepo.UpdateAsync(userId, id, process);

                if (updated == null) return NotFound();

                return Ok(automapper.Map<TechProcessDto, TechProcess>(updated));
            }
            catch (DbUpdateException ex)
            {
                var uniqueEx = ex.IsUniqueKeyException();
                if (uniqueEx is not null) return uniqueEx;
                return StatusCode(500, ex);
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

            var deleted = await techRepo.DeleteAsync(userId, id);

            if (deleted == null) return NotFound();

            return NoContent();
        }
    }
}