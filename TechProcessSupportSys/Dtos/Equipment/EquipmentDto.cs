using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Equipment
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Model { get; set; } = "";
        public string GOST { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}
