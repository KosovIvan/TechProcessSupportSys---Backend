using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Operation
{
    public class UpdateOperationDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; } = "";
        [MaxLength(250)]
        public string Description { get; set; } = "";
        [Required]
        [Range(1, 120)]
        public int Duration { get; set; }
        [Required]
        public string StepOrder { get; set; } = "";
    }
}