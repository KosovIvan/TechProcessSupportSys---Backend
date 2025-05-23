using System.ComponentModel.DataAnnotations.Schema;
using TechProcessSupportSys.Dtos.Equipment;
using TechProcessSupportSys.Dtos.Fixture;
using TechProcessSupportSys.Dtos.Tool;

namespace TechProcessSupportSys.Dtos.Transition
{
    public class TransitionExpandedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int StepOrder { get; set; }
        [NotMapped]
        public ToolDto Tool { get; set; }
        [NotMapped]
        public EquipmentDto Equipment { get; set; }
        [NotMapped]
        public FixtureDto Fixture { get; set; }
    }
}
