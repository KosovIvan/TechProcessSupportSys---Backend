using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechProcessSupportSys.Dtos.Equipment;
using TechProcessSupportSys.Dtos.Fixture;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Mappers;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private readonly IFixtureRepository fixtureRepo;

        public FixtureController(IFixtureRepository fixtureRepo)
        {
            this.fixtureRepo = fixtureRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FixtureQueryObject query)
        {
            var fixture = await fixtureRepo.GetAllAsync(query);

            var fixtureDto = fixture.Select(e => e.ToFixtureDto()).ToList();

            return Ok(fixtureDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var fixture = await fixtureRepo.GetByIdAsync(id);

            if (fixture == null) return NotFound();

            return Ok(fixture.ToFixtureDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFixtureDto createFixtureDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Дал мне говно");
            }

            var fixture = createFixtureDto.FromCreateFixtureDto();

            await fixtureRepo.CreateAsync(fixture);

            return CreatedAtAction(nameof(GetById), new { id = fixture.Id }, fixture.ToFixtureDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFixtureDto updateFixtureDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Дал мне говно");
            }

            var fixture = updateFixtureDto.FromUpdateFixtureDto();

            var updated = await fixtureRepo.UpdateAsync(id, fixture);

            if (updated == null) return NotFound();

            return Ok(updated.ToFixtureDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await fixtureRepo.DeleteAsync(id);

            if (deleted == null) return NotFound();

            return NoContent();
        }
    }
}
