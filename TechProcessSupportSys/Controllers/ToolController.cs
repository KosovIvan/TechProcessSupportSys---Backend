using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechProcessSupportSys.Dtos.Tool;
using TechProcessSupportSys.Extentions;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Controllers
{
    [ApiController]
    [Route("App/[controller]")]
    public class ToolController : ControllerBase
    {
        private readonly IAutomapper automapper;
        private readonly IToolRepository toolRepo;
        private readonly UserManager<User> userManager;

        public ToolController(IAutomapper automapper, IToolRepository toolRepo, UserManager<User> userManager)
        {
            this.automapper = automapper;
            this.toolRepo = toolRepo;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] ToolQueryObject query)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var id = User.IsInRole("Admin") ? null : user!.Id;

            var tools = await toolRepo.GetAllAsync(id, query);

            var toolsDto = tools.Select(t => automapper.Map<ToolDto, Tool>(t)).ToList();

            return Ok(toolsDto);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var userId = User.IsInRole("Admin") ? null : user!.Id;

            var tool = await toolRepo.GetByIdAsync(userId, id);

            if (tool == null) return NotFound();

            return Ok(automapper.Map<ToolDto, Tool>(tool));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateToolDto createToolDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);

            var tool = automapper.Map<Tool, CreateToolDto>(createToolDto);
            tool.UserId = user!.Id;

            await toolRepo.CreateAsync(tool);

            return CreatedAtAction(nameof(GetById), new { id = tool.Id }, automapper.Map<ToolDto, Tool>(tool));
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateToolDto updateToolDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var userId = User.IsInRole("Admin") ? null : user!.Id;

            var tool = automapper.Map<Tool, UpdateToolDto>(updateToolDto);

            var updated = await toolRepo.UpdateAsync(userId, id, tool);

            if (updated == null) return NotFound();

            return Ok(automapper.Map<ToolDto, Tool>(updated));
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var userId = User.IsInRole("Admin") ? null : user!.Id;

            var deleted = await toolRepo.DeleteAsync(userId, id);

            if (deleted == null) return NotFound();

            return NoContent();
        }
    }
}