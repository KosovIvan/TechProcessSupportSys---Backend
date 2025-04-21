using System.ComponentModel.DataAnnotations.Schema;

namespace TechProcessSupportSys.Models
{
    [Table("Transitions")]
    public class Transition
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public double Duration { get; set; }
        public int StepOrder { get; set; }
        public int OperationId { get; set; }
        public int? ToolId { get; set; }
        public int? EquipmentId { get; set; }
        public int? FixtureId { get; set; }
        public Operation Operation { get; set; } = null!;
        public Tool? Tool { get; set; }
        public Equipment? Equipment { get; set; }
        public Fixture? Fixture { get; set; }
    }
}
