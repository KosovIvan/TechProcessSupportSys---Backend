using System.ComponentModel.DataAnnotations.Schema;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Dtos.TechProcess
{
    public class TechProcessExtendedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public string ProductName { get; set; } = "";
        public string Description { get; set; } = "";
        [NotMapped]
        public string Status { get; set; } = "";
        public string Author { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}
