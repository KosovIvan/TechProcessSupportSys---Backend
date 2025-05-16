using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace TechProcessSupportSys.Extentions
{
    public static class DbUpdateExceptionExtentions
    {
        public static IActionResult? IsUniqueKeyException(this DbUpdateException ex)
        {
            string pattern = @"Нарушено ""AK_(\w+)_(\w+)"" ограничения UNIQUE KEY.";
            Match match = Regex.Match(ex.InnerException == null ? "" : ex.InnerException.Message, pattern);
            if (match.Value != "")
            {
                string message = $"Поле {match.Groups[2].Value} таблицы {match.Groups[1].Value} должно иметь уникальные значения";
                return new BadRequestObjectResult(message);
            }
            return null;
        }
    }
}
