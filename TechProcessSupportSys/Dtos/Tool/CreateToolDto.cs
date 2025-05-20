using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Tool
{
    public class CreateToolDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = "";
        [MaxLength(500)]
        public string Description { get; set; } = "";
        [Required]
        [MaxLength(35)]
        public string Type { get; set; } = "";
        [Required]
        [MaxLength(35)]
        public string Material { get; set; } = "";
        [RegularExpression(@"(ГОСТ\s\d{1,5}(\.\d{1,4}){0,2}-(\d{4}|\d{2})|)")]
        public string GOST { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}
