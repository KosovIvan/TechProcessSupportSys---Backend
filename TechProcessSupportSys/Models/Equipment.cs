using System.ComponentModel.DataAnnotations.Schema;

namespace TechProcessSupportSys.Models
{
    [Table("Equipment")]
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Model { get; set; } = "";
        public string GOST { get; set; } = "";
        public string Author { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
        public string UserId { get; set; } = "";
        public User User { get; set; } = null!;
        public List<Transition> Transition { get; set; } = new List<Transition>();
    }
}
