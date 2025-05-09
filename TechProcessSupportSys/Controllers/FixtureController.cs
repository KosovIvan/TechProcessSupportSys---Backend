using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechProcessSupportSys.Dtos.Equipment;
using TechProcessSupportSys.Dtos.Fixture;
using TechProcessSupportSys.Extentions;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private readonly IAutomapper automapper;
        private readonly IFixtureRepository fixtureRepo;
        private readonly UserManager<User> userManager;

        public FixtureController(IAutomapper automapper, IFixtureRepository fixtureRepo, UserManager<User> userManager)
        {
            this.automapper = automapper;
            this.fixtureRepo = fixtureRepo;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FixtureQueryObject query)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var id = User.IsInRole("Admin") ? null : user!.Id;

            var fixture = await fixtureRepo.GetAllAsync(id, query);

            var fixtureDto = fixture.Select(e => automapper.Map<FixtureDto, Fixture>(e)).ToList();

            return Ok(fixtureDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var userId = User.IsInRole("Admin") ? null : user!.Id;

            var fixture = await fixtureRepo.GetByIdAsync(userId, id);

            if (fixture == null) return NotFound();

            return Ok(automapper.Map<FixtureDto, Fixture>(fixture));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFixtureDto createFixtureDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);

            var fixture = automapper.Map<Fixture, CreateFixtureDto>(createFixtureDto);
            fixture.UserId = user!.Id;

            await fixtureRepo.CreateAsync(fixture);

            return CreatedAtAction(nameof(GetById), new { id = fixture.Id }, automapper.Map<FixtureDto, Fixture>(fixture));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFixtureDto updateFixtureDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var userId = User.IsInRole("Admin") ? null : user!.Id;

            var fixture = automapper.Map<Fixture, UpdateFixtureDto>(updateFixtureDto);

            var updated = await fixtureRepo.UpdateAsync(userId, id, fixture);

            if (updated == null) return NotFound();

            return Ok(automapper.Map<FixtureDto, Fixture>(updated));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var userId = User.IsInRole("Admin") ? null : user!.Id;

            var deleted = await fixtureRepo.DeleteAsync(userId, id);

            if (deleted == null) return NotFound();

            return NoContent();
        }
    }
}