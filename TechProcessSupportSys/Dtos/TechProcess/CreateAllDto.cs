namespace TechProcessSupportSys.Dtos.TechProcess
{
    public class CreateAllDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = "";
        public string ProcessName { get; set; } = "";
        public string? OperationName { get; set; }
        public string? TransitionName { get; set; }
        public string? ToolName { get; set; }
        public string? EquipmentName { get; set; }
        public string? FixtureName { get; set; }
    }
}
