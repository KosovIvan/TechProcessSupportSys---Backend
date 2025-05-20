namespace TechProcessSupportSys.QueryObjects
{
    public class TechProcessQueryObject
    {
        public string? Name { get; set; } = null;
        public string? Code { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public bool IsGlobal { get; set; } = true;
        public bool IsPrivate { get; set; } = false;
        public bool IsExpanded { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
