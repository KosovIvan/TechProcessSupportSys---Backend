using System.Security.Claims;

namespace TechProcessSupportSys.Extentions
{
    public static class ClaimsExtentions
    {
        public static string? GetUsername(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;
        }
    }
}