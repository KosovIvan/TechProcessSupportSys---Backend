using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechProcessSupportSys.Dtos.Equipment;
using TechProcessSupportSys.Dtos.Tool;
using TechProcessSupportSys.Extentions;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Mappers;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentRepository equipRepo;
        private readonly UserManager<User> userManager;

        public EquipmentController(IEquipmentRepository equipRepo, UserManager<User> userManager)
        {
            this.equipRepo = equipRepo;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] EquipmentQueryObject query)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username);
            var id = User.IsInRole("Admin") ? null : user!.Id;

            var equip = await equipRepo.GetAllAsync(id, query);

            var equipDto = equip.Select(e => e.ToEquipmentDto()).ToList();

            return Ok(equipDto);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username);
            var userId = User.IsInRole("Admin") ? null : user!.Id;

            var equip = await equipRepo.GetByIdAsync(userId, id);

            if (equip == null) return NotFound();

            return Ok(equip.ToEquipmentDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateEquipmentDto createEquipmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Дал мне говно");
            }

            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username);

            var equip = createEquipmentDto.FromCreateEquipmentDto();
            equip.UserId = user!.Id;

            await equipRepo.CreateAsync(equip);

            return CreatedAtAction(nameof(GetById), new { id = equip.Id }, equip.ToEquipmentDto());
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEquipmentDto updateEquipmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Дал мне говно");
            }

            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username);
            var userId = User.IsInRole("Admin") ? null : user!.Id;

            var equip = updateEquipmentDto.FromUpdateEquipmentDto();

            var updated = await equipRepo.UpdateAsync(userId, id, equip);

            if (updated == null) return NotFound();

            return Ok(updated.ToEquipmentDto());
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username);
            var userId = User.IsInRole("Admin") ? null : user!.Id;

            var deleted = await equipRepo.DeleteAsync(userId, id);

            if (deleted == null) return NotFound();

            return NoContent();
        }
    }
}
