using System.ComponentModel.DataAnnotations.Schema;

namespace TechProcessSupportSys.Models
{
    [Table("Blank")]
    public class Blank
    {
        public int Id { get; set; }
        public string Asortment { get; set; } = "";
        public string? AsortmentGOST { get; set; }
        public string Material { get; set; } = "";
        public string? MaterialStateCode { get; set; }
        public string? MaterialGOST { get; set; }
        public double Length {  get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Diameter { get; set; }
        public bool IsPrivate { get; set; } = false;
        public string Author { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = "";
        public string UserId { get; set; } = "";
        public User User { get; set; } = null!;
        public List<TechProcess> Processes { get; set; } = new List<TechProcess>();
    }
}
