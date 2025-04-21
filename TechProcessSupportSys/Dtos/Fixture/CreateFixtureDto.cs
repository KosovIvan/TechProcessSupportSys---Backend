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
    }
}
