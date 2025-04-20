using System.ComponentModel.DataAnnotations.Schema;

namespace TechProcessSupportSys.Models
{
    [Table("Equipment")]
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string? Model { get; set; }
        public List<Transition> Transition { get; set; } = new List<Transition>();
    }
}
