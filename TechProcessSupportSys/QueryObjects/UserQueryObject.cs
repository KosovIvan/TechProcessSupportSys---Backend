namespace TechProcessSupportSys.QueryObjects
{
    public class UserQueryObject
    {
        public string? Login { get; set; } = null;
        public string? Name { get; set; } = null;
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; } = false;
        public bool Revoked { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
