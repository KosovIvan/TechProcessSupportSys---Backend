using Microsoft.AspNetCore.Identity;

namespace TechProcessSupportSys.Models
{
    public class User : IdentityUser
    {
        public List<TechProcess> Processs { get; set; } = new List<TechProcess>();
    }
}
