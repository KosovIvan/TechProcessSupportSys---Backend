using System.ComponentModel.DataAnnotations;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Dtos.TechProcess
{
    public class UpdateTechProcessDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = "";
        [Required]
        [RegularExpression(@"ТП\.\d{4}\.\d{3}\.\d{2}")]
        public string Code { get; set; } = "";
        [Required]
        [MaxLength(40)]
        public string ProductName { get; set; } = "";
        [MaxLength(500)]
        public string Description { get; set; } = "";
        public ProcessStatus? Status { get; set; } = ProcessStatus.Draft;
        [Required]
        public bool? IsPrivate { get; set; }
        public int? BlankId { get; set; }
    }
}
