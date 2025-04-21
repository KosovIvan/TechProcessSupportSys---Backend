using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechProcessSupportSys.Dtos.Equipment;
using TechProcessSupportSys.Dtos.Tool;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Mappers;

namespace TechProcessSupportSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentRepository equipRepo;

        public EquipmentController(IEquipmentRepository equipRepo)
        {
            this.equipRepo = equipRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equip = await equipRepo.GetAllAsync();

            var equipDto = equip.Select(e => e.ToEquipmentDto()).ToList();

            return Ok(equipDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var equip = await equipRepo.GetByIdAsync(id);

            if (equip == null) return NotFound();

            return Ok(equip.ToEquipmentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEquipmentDto createEquipmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Дал мне говно");
            }

            var equip = createEquipmentDto.FromCreateEquipmentDto();

            await equipRepo.CreateAsync(equip);

            return CreatedAtAction(nameof(GetById), new { id = equip.Id }, equip.ToEquipmentDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEquipmentDto updateEquipmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Дал мне говно");
            }

            var equip = updateEquipmentDto.FromUpdateEquipmentDto();

            var updated = await equipRepo.UpdateAsync(id, equip);

            if (updated == null) return NotFound();

            return Ok(updated.ToEquipmentDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await equipRepo.DeleteAsync(id);

            if (deleted == null) return NotFound();

            return NoContent();
        }
    }
}
