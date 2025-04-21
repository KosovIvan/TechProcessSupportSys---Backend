using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using TechProcessSupportSys.Dtos.Tool;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Mappers;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Controllers
{
    [ApiController]
    [Route("App/[controller]")]
    public class ToolController : ControllerBase
    {
        private readonly IToolRepository toolRepo;

        public ToolController(IToolRepository toolRepo)
        {
            this.toolRepo = toolRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ToolQueryObject query)
        {
            var tools = await toolRepo.GetAllAsync(query);

            var toolsDto = tools.Select(t => t.ToToolDto()).ToList();

            return Ok(toolsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tool = await toolRepo.GetByIdAsync(id);

            if (tool == null) return NotFound();

            return Ok(tool.ToToolDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateToolDto createToolDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Дал мне говно");
            }

            var tool = createToolDto.FromCreateToolDto();

            await toolRepo.CreateAsync(tool);

            return CreatedAtAction(nameof(GetById), new { id = tool.Id }, tool.ToToolDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateToolDto updateToolDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Дал мне говно");
            }

            var tool = updateToolDto.FromUpdateToolDto();

            var updated = await toolRepo.UpdateAsync(id, tool);

            if (updated == null) return NotFound();

            return Ok(updated.ToToolDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await toolRepo.DeleteAsync(id);

            if (deleted == null) return NotFound();

            return NoContent();
        }
    }
}