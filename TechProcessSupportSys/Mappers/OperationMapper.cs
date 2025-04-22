using TechProcessSupportSys.Dtos.Operation;
using TechProcessSupportSys.Dtos.Tool;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Mappers
{
    public static class OperationMapper
    {
        public static OperationDto ToOperationDto(this Operation operation)
        {
            return new OperationDto
            {
                Id = operation.Id,
                Name = operation.Name,
                Description = operation.Description,
                StepOrder = operation.StepOrder,
            };
        }

        public static Operation FromCreateOperationDto(this CreateOperationDto createOperationDto)
        {
            return new Operation
            {
                Name = createOperationDto.Name,
                Description = createOperationDto.Description,
                StepOrder = createOperationDto.StepOrder
            };
        }

        public static Operation FromUpdateOperationDto(this UpdateOperationDto updateToolDto)
        {
            return new Operation
            {
                Name = updateToolDto.Name,
                Description = updateToolDto.Description,
                StepOrder = updateToolDto.StepOrder
            };
        }
    }
}
