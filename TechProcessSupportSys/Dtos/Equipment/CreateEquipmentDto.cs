using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Equipment
{
    public class CreateEquipmentDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; } = "";
        [MaxLength(250)]
        public string Description { get; set; } = "";
        [MaxLength(35)]
        public string Model { get; set; } = "";
    }
}
