namespace TechProcessSupportSys.Dtos.Operation
{
    public class OperationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string StepOrder { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}