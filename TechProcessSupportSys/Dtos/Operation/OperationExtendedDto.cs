namespace TechProcessSupportSys.Dtos.Operation
{
    public class OperationExtendedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Duration { get; set; }
        public string StepOrder { get; set; } = "";
        public string Author { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}
