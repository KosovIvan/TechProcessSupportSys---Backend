using System.ComponentModel.DataAnnotations.Schema;

namespace TechProcessSupportSys.Models
{
    [Table("Operations")]
    public class Operation
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Duration { get; set; }
        public string StepOrder { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
        public int ProcessId { get; set; }
        public TechProcess Process { get; set; } = null!;
        public List<Transition> Transitions { get; set; } = new List<Transition>();
    }
}