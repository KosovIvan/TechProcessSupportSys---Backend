using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Fixture
{
    public class CreateFixtureDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; } = "";
        [MaxLength(250)]
        public string Description { get; set; } = "";
        [Required]
        [MaxLength(35)]
        public string Type { get; set; } = "";
        [RegularExpression(@"(ГОСТ\s\d{1,5}(\.\d{1,4}){0,2}-(\d{4}|\d{2})|)")]
        public string GOST { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}
