using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.TechProcess
{
    public class CreateTechProcessDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; } = "";
        [Required]
        [MaxLength(10)]
        public string Code { get; set; } = "";
        [Required]
        [MaxLength(35)]
        public string ProductName { get; set; } = "";
        [MaxLength(250)]
        public string Description { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}
