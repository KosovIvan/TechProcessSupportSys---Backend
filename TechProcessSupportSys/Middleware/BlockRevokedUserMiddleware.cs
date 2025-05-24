using Microsoft.AspNetCore.Identity;
using TechProcessSupportSys.Extentions;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Middleware
{
    public class BlockRevokedUserMiddleware
    {
        private readonly RequestDelegate _next;

        public BlockRevokedUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<User> userManager)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var userLogin = context.User.GetUsername();
                var user = await userManager.FindByNameAsync(userLogin);
                if (user == null || user.RevokedOn != null)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Access denied: user is blocked.");
                    return;
                }
            }

            await _next(context);
        }
    }
}