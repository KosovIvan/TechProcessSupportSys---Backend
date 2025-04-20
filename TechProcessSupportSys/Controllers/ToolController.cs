using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using TechProcessSupportSys.Dtos.Tool;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Mappers;
using TechProcessSupportSys.Models;

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
        public async Task<IActionResult> GetAll()
        {
            var tools = await toolRepo.GetAllAsync();

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
    }
}