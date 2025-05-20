using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Operation
{
    public class CreateOperationDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; } = "";
        [MaxLength(250)]
        public string Description { get; set; } = "";
        [Required]
        [Range(1, 120)]
        public int Duration { get; set; }
        [RegularExpression(@"\d{3}")]
        public string? StepOrder { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}