using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.Extentions;

namespace TechProcessSupportSys.Attributes
{
    public class ActiveUserAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userManager = context.HttpContext.RequestServices.GetService(typeof(UserManager<User>)) as UserManager<User>;

            if (userManager == null)
            {
                context.Result = new StatusCodeResult(500);
                return;
            }

            var userLogin = context.HttpContext.User.GetUsername();
            if (userLogin == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var user = await userManager.FindByNameAsync(userLogin);
            if (user == null || user.RevokedOn != null)
            {
                context.Result = new UnauthorizedObjectResult("Пользователь неактивен или удалён");
            }
        }
    }
}