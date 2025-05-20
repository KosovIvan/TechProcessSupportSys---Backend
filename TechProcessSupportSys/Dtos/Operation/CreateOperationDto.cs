using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Operation
{
    public class CreateOperationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = "";
        [MaxLength(500)]
        public string Description { get; set; } = "";
        [Required]
        [Range(1, 43200)]
        public int Duration { get; set; }
        [RegularExpression(@"\d{3}")]
        public string? StepOrder { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}