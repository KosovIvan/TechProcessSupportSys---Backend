using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechProcessSupportSys.QueryObjects
{
    public class BlankQueryObject
    {
        public string? Asortment { get; set; } = null;
        public string? Material { get; set; } = null;
        public string? GOST { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public bool IsGlobal { get; set; } = true;
        public bool IsPrivate { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
