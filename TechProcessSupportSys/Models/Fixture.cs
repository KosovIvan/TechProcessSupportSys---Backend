using System.ComponentModel.DataAnnotations.Schema;

namespace TechProcessSupportSys.Models
{
    [Table("Fixtures")]
    public class Fixture
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<Transition> Transition { get; set; } = new List<Transition>();
    }
}