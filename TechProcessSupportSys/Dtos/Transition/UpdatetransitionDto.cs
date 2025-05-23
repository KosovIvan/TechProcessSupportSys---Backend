using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Transition
{
    public class UpdateTransitionDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = "";
        [MaxLength(500)]
        public string Description { get; set; } = "";
        [Required]
        [Range(1, 60)]
        public double Duration { get; set; }
        [Range(1, 50)]
        public int? StepOrder { get; set; }
        [Required]
        public bool? IsPrivate { get; set; }
        public int? ToolId { get; set; }
        public int? EquipmentId { get; set; }
        public int? FixtureId { get; set; }
    }
}
