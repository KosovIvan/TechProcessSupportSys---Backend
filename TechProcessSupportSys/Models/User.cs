using Microsoft.AspNetCore.Identity;

namespace TechProcessSupportSys.Models
{
    public class User : IdentityUser
    {
        public List<TechProcess> Processs { get; set; } = new List<TechProcess>();
        public List<Tool> Tools { get; set; } = new List<Tool>();
        public List<Equipment> Equipment { get; set; } = new List<Equipment>();
        public List<Fixture> Fixtures { get; set; } = new List<Fixture>();
    }
}
