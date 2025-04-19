using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}