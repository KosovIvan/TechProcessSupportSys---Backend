using Microsoft.EntityFrameworkCore;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> CheckLogin(string login)
        {
            if (await context.Users.AnyAsync(u => u.UserName == login)) return false;
            return true;
        }

        public async Task<User?> DeleteUserByLogin(User user, string? deleterLogin)
        {
            user.RevokedOn = DateTime.Now;
            user.RevokedBy = deleterLogin;

            await context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> IsRevoked(string login)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == login);
            if ((existingUser == null) || (existingUser.RevokedOn != null)) return true;
            return false;
        }

        public async Task<User?> UpdateRecover(string login)
        {
            var recoveredUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == login);

            if (recoveredUser == null) return null;

            recoveredUser.RevokedOn = null;
            recoveredUser.RevokedBy = "";

            await context.SaveChangesAsync();

            return recoveredUser;
        }
    }
}
