using System.ComponentModel.DataAnnotations.Schema;

namespace TechProcessSupportSys.Models
{
    [Table("TechProcesses")]
    public class TechProcess
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UserId { get; set; } = "";
        public User User { get; set; } = null!;
        public List<Operation> Operations { get; set; } = new List<Operation>();
    }
}
