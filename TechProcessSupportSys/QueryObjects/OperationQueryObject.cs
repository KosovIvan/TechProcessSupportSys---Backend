namespace TechProcessSupportSys.QueryObjects
{
    public class OperationQueryObject
    {
        public bool IsGlobal { get; set; } = true;
        public bool IsPrivate { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
