namespace TechProcessSupportSys.Dtos.Transition
{
    public class TransitionExtendedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public double Duration { get; set; }
        public int StepOrder { get; set; }
        public string Author { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
        public int? ToolId { get; set; }
        public int? EquipmentId { get; set; }
        public int? FixtureId { get; set; }
    }
}
