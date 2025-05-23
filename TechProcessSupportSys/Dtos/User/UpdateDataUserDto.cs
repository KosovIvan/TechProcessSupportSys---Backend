using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.User
{
    public class UpdateDataUserDto
    {
        [Required]
        public string Login { get; set; } = "";
        [Required]
        [RegularExpression(@"^(([А-ЯЁ][а-яё]+)(\s[А-ЯЁ][а-яё]+)?)|(([A-Z][a-z]+)(\s[A-Z][a-z]+)?)$")]
        public string Name { get; set; } = "";
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
    }
}
