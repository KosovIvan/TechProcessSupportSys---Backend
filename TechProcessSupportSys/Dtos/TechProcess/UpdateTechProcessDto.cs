using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.TechProcess
{
    public class UpdateTechProcessDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; } = "";
        [MaxLength(250)]
        public string Description { get; set; } = "";
    }
}
