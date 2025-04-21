using TechProcessSupportSys.Dtos.Equipment;
using TechProcessSupportSys.Dtos.Tool;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Mappers
{
    public static class EquipmentMapper
    {
        public static EquipmentDto ToEquipmentDto(this Equipment equip)
        {
            return new EquipmentDto
            {
                Id = equip.Id,
                Name = equip.Name,
                Description = equip.Description,
                Model = equip.Model
            };
        }

        public static Equipment FromCreateEquipmentDto(this CreateEquipmentDto createEquipmentDto)
        {
            return new Equipment
            {
                Name = createEquipmentDto.Name,
                Description = createEquipmentDto.Description,
                Model = createEquipmentDto.Model
            };
        }

        public static Equipment FromUpdateEquipmentDto(this UpdateEquipmentDto updateEquipmentDto)
        {
            return new Equipment
            {
                Name = updateEquipmentDto.Name,
                Description = updateEquipmentDto.Description,
                Model = updateEquipmentDto.Model
            };
        }
    }
}
