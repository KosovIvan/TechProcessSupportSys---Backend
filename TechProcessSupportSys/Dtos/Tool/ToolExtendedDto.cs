namespace TechProcessSupportSys.Dtos.Tool
{
    public class ToolExtendedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public string Material { get; set; } = "";
        public string GOST { get; set; } = "";
        public string Author { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}
