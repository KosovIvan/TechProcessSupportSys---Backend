using System.ComponentModel.DataAnnotations.Schema;
using TechProcessSupportSys.Dtos.Operation;

namespace TechProcessSupportSys.Dtos.TechProcess
{
    public class TechProcessExpandedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public string ProductName { get; set; } = "";
        [NotMapped]
        public List<OperationExpandedDto> Operations { get; set; }
    }
}
