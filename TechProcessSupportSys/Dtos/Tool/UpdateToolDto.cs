using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Tool
{
    public class UpdateToolDto
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
        [MaxLength(15)]
        public string GOST { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}
