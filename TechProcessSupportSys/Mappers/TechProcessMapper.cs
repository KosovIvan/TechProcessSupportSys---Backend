using TechProcessSupportSys.Dtos.TechProcess;
using TechProcessSupportSys.Dtos.Tool;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Mappers
{
    public static class TechProcessMapper
    {
        public static AllDto ToAllDto(this CreateAllDto createAllDto)
        {
            return new AllDto
            {
                Id = createAllDto.Id,
                ProcessName = createAllDto.ProcessName,
                OperationName = createAllDto.OperationName,
                TransitionName = createAllDto.TransitionName,
                ToolName = createAllDto.ToolName,
                EquipmentName = createAllDto.EquipmentName,
                FixtureName = createAllDto.FixtureName
            };
        }
        public static TechProcessDto ToTechProcessDto(this TechProcess process)
        {
            return new TechProcessDto
            {
                Id = process.Id,
                Name = process.Name,
                Description = process.Description,
                CreatedAt = process.CreatedAt
            };
        }

        public static TechProcess FromCreateTechProcessDto(this CreateTechProcessDto createTechProcessDto)
        {
            return new TechProcess
            {
                Name = createTechProcessDto.Name,
                Description = createTechProcessDto.Description
            };
        }

        public static TechProcess FromUpdateTechProcessDto(this UpdateTechProcessDto updateTechProcessDto)
        {
            return new TechProcess
            {
                Name = updateTechProcessDto.Name,
                Description = updateTechProcessDto.Description
            };
        }
    }
}
