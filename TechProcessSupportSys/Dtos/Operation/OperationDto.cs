namespace TechProcessSupportSys.Dtos.Operation
{
    public class OperationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int StepOrder { get; set; }
    }
}