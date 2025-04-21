namespace TechProcessSupportSys.QueryObjects
{
    public class ToolQueryObject
    {
        public string? Name { get; set; } = null;
        public string? Type { get; set; } = null;
        public string? Material { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
