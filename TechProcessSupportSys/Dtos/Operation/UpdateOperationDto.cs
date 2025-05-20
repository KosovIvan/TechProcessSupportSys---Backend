using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Operation
{
    public class UpdateOperationDto
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
        [Required]
        public bool? IsPrivate { get; set; }
    }
}