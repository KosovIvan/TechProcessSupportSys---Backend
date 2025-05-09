namespace TechProcessSupportSys.Dtos.Transition
{
    public class TransitionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public double Duration { get; set; }
        public int StepOrder { get; set; }
        public string TechProcessName { get; set; } = "";
        public string OperationName { get; set; } = "";
    }
}
