using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Operation
{
    public class CreateOperationDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; } = "";
        [Required]
        [Range(1, 99999)]
        public int Code { get; set; }
        [MaxLength(250)]
        public string Description { get; set; } = "";
        [Required]
        [Range(1, 120)]
        public int Duration { get; set; }
        [Required]
        [Range(1,50)]
        public int StepOrder { get; set; }
    }
}