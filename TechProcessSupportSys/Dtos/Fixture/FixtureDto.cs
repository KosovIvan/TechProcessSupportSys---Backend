using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Fixture
{
    public class FixtureDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string GOST { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}
