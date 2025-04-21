using TechProcessSupportSys.Dtos.Equipment;
using TechProcessSupportSys.Dtos.Fixture;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Mappers
{
    public static class FixtureMapper
    {
        public static FixtureDto ToFixtureDto(this Fixture fixture)
        {
            return new FixtureDto
            {
                Id = fixture.Id,
                Name = fixture.Name,
                Description = fixture.Description,
                Type = fixture.Type
            };
        }

        public static Fixture FromCreateFixtureDto(this CreateFixtureDto createFixtureDto)
        {
            return new Fixture
            {
                Name = createFixtureDto.Name,
                Description = createFixtureDto.Description,
                Type = createFixtureDto.Type
            };
        }

        public static Fixture FromUpdateFixtureDto(this UpdateFixtureDto updateFixtureDto)
        {
            return new Fixture
            {
                Name = updateFixtureDto.Name,
                Description = updateFixtureDto.Description,
                Type = updateFixtureDto.Type
            };
        }
    }
}
