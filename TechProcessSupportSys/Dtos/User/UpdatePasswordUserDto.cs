using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.User
{
    public class UpdatePasswordUserDto
    {
        [Required]
        public string OldPassword { get; set; } = "";
        [Required]
        public string NewPassword { get; set; } = "";
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = "";
    }
}
