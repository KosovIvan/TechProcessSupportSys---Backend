using System.ComponentModel.DataAnnotations.Schema;

namespace TechProcessSupportSys.Models
{
    [Table("Tools")]
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public string Material { get; set; } = "";
        public string UserId { get; set; } = "";
        public User User { get; set; } = null!;
        public List<Transition> Transition { get; set; } = new List<Transition>();
    }
}
