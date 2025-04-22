namespace TechProcessSupportSys.QueryObjects
{
    public class AllQueryObject
    {
        public string? ProcessName { get; set; } = null;
        public string? OperationName { get; set; } = null;
        public string? TransitionName { get; set; } = null;
        public string? ToolName { get; set; } = null;
        public string? EquipmentName { get; set; } = null;
        public string? FixtureName { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
