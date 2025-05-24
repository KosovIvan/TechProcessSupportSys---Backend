using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TechProcessSupportSys.Extentions;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Util
{
    public class ActiveUserTokenHandler : AuthorizationHandler<ActiveUserTokenRequirement>
    {
        private readonly UserManager<User> userManager;
        public ActiveUserTokenHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ActiveUserTokenRequirement requirement)
        {
            var userLogin = context.User.GetUsername();
            var iatClaim = context.User.FindFirst(JwtRegisteredClaimNames.Iat)?.Value;

            if (userLogin == null || iatClaim == null || !long.TryParse(iatClaim, out var iatUnix))
            {
                context.Fail();
                return;
            }

            var tokenIssuedAt = DateTimeOffset.FromUnixTimeSeconds(iatUnix).UtcDateTime;

            var user = await userManager.FindByNameAsync(userLogin);

            /*if (user == null || user.RevokedOn != null || tokenIssuedAt < user.LastTokenValidAfter)
            {
                context.Fail();
                return;
            }*/

            context.Succeed(requirement);
        }
    }
}
