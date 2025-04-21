using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Interfaces
{
    public interface IFixtureRepository
    {
        Task<Fixture> CreateAsync(Fixture fixture);

        Task<Fixture?> DeleteAsync(int id);

        Task<List<Fixture>> GetAllAsync();

        Task<Fixture?> GetByIdAsync(int id);

        Task<Fixture?> UpdateAsync(int id, Fixture fixture);
    }
}
