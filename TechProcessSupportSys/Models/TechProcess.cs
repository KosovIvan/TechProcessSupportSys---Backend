using System.ComponentModel.DataAnnotations.Schema;

namespace TechProcessSupportSys.Models
{
    [Table("TechProcesses")]
    public class TechProcess
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public string ProductName { get; set; } = "";
        public string Description { get; set; } = "";
        public ProcessStatus Status { get; set; } = ProcessStatus.Draft;
        public bool IsPrivate { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Author { get; set; } = "";
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = "";
        public string UserId { get; set; } = "";
        public int? BlankId { get; set; }
        public User User { get; set; } = null!;
        public Blank? Blank { get; set; }
        public List<Operation> Operations { get; set; } = new List<Operation>();
    }

    public enum ProcessStatus
    {
        Draft,
        InReview,
        Approved,
        Rejected,
        Archived,
        Active,
        Deprecated,
        Published,
        Pending
    }
}
