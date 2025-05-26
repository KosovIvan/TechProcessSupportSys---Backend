using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechProcessSupportSys.Dtos.Blank;
using TechProcessSupportSys.Dtos.Equipment;
using TechProcessSupportSys.Extentions;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlankController : ControllerBase
    {
        private readonly IAutomapper automapper;
        private readonly IBlankRepository blankRepo;
        private readonly UserManager<User> userManager;

        public BlankController(IAutomapper automapper, IBlankRepository blankRepo, UserManager<User> userManager)
        {
            this.automapper = automapper;
            this.blankRepo = blankRepo;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BlankQueryObject query)
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

            var blank = await blankRepo.GetAllAsync(isAdmin, userId, query);

            var blankDto = blank.Select(b => automapper.Map<BlankDto, Blank>(b)).ToList();

            return Ok(blankDto);
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
                isAdmin = await userManager.IsInRoleAsync(user, "Admin");
            }

            var blank = await blankRepo.GetByIdAsync(isAdmin, userId, id);

            if (blank == null) return NotFound();

            return Ok(automapper.Map<BlankExtendedDto, Blank>(blank));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateBlankDto createBlankDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);

            var blank = automapper.Map<Blank, CreateBlankDto>(createBlankDto);
            blank.UserId = user!.Id;
            blank.Author = username;
            blank.UpdatedAt = DateTime.UtcNow;
            blank.UpdatedBy = username;

            await blankRepo.CreateAsync(blank);

            return CreatedAtAction(nameof(GetById), new { id = blank.Id }, automapper.Map<BlankDto, Blank>(blank));
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBlankDto updateBlankDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var userId = await userManager.IsInRoleAsync(user, "Admin") ? null : user!.Id;

            var blank = automapper.Map<Blank, UpdateBlankDto>(updateBlankDto);
            blank.UpdatedAt = DateTime.UtcNow;
            blank.UpdatedBy = username;

            var updated = await blankRepo.UpdateAsync(userId, id, blank);

            if (updated == null) return NotFound();

            return Ok(automapper.Map<BlankDto, Blank>(updated));
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var userId = await userManager.IsInRoleAsync(user, "Admin") ? null : user!.Id;

            var deleted = await blankRepo.DeleteAsync(userId, id);

            if (deleted == null) return NotFound();

            return NoContent();
        }
    }
}