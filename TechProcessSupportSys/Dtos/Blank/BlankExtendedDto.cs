namespace TechProcessSupportSys.Dtos.Blank
{
    public class BlankExtendedDto
    {
        public int Id { get; set; }
        public string Asortment { get; set; } = "";
        public string? AsortmentGOST { get; set; }
        public string Material { get; set; } = "";
        public string? MaterialStateCode { get; set; }
        public string? MaterialGOST { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Diameter { get; set; }
        public bool IsPrivate { get; set; } = false;
        public string Author { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = "";
    }
}
