namespace TechProcessSupportSys.Dtos.Equipment
{
    public class EquipmentExtendedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Model { get; set; } = "";
        public string GOST { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
        public string Author { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = "";
    }
}
