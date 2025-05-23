namespace TechProcessSupportSys.Dtos.User
{
    public class UserOutputDto
    {
        public string Login { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "";
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public string RevokedBy { get; set; } = "";
    }
}
