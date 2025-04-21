using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}