using TechProcessSupportSys.Dtos.Tool;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Mappers
{
    public static class ToolMapper
    {
        public static ToolDto ToToolDto(this Tool tool)
        {
            return new ToolDto
            {
                Id = tool.Id,
                Name = tool.Name,
                Description = tool.Description,
                Type = tool.Type,
                Material = tool.Material
            };
        }

        public static Tool FromCreateToolDto(this CreateToolDto createToolDto)
        {
            return new Tool
            {
                Name = createToolDto.Name,
                Description = createToolDto.Description,
                Type = createToolDto.Type,
                Material = createToolDto.Material
            };
        }

        public static Tool FromUpdateToolDto(this UpdateToolDto updateToolDto)
        {
            return new Tool
            {
                Name = updateToolDto.Name,
                Description = updateToolDto.Description,
                Type = updateToolDto.Type,
                Material = updateToolDto.Material
            };
        }
    }
}