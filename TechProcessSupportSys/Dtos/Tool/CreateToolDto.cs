using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Tool
{
    public class CreateToolDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; } = "";
        [MaxLength(250)]
        public string Description { get; set; } = "";
        [Required]
        [MaxLength(35)]
        public string Type { get; set; } = "";
        [Required]
        [MaxLength(35)]
        public string Material { get; set; } = "";
    }
}
