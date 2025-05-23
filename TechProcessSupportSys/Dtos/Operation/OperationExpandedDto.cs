using System.ComponentModel.DataAnnotations.Schema;
using TechProcessSupportSys.Dtos.Transition;

namespace TechProcessSupportSys.Dtos.Operation
{
    public class OperationExpandedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string StepOrder { get; set; } = "";
        [NotMapped]
        public List<TransitionExpandedDto> Transitions { get; set; }
    }
}
