namespace TechProcessSupportSys.Dtos.Transition
{
    public class TransitionOsnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public double Duration { get; set; }
        public int StepOrder { get; set; }
        public bool IsPrivate { get; set; } = false;
        public int? ToolId { get; set; }
        public int? EquipmentId { get; set; }
        public int? FixtureId { get; set; }
    }
}
