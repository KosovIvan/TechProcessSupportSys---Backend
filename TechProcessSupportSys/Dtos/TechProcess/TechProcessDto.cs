namespace TechProcessSupportSys.Dtos.TechProcess
{
    public class TechProcessDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public string ProductName { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
