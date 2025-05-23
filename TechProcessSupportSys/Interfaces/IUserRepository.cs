using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CheckLogin(string login);
        Task<User?> DeleteUserByLogin(User user, string? deleterLogin);
        Task<bool> IsRevoked(string login);
        Task<User?> UpdateRecover(string login);
    }
}
