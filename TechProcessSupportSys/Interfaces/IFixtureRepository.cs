using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Interfaces
{
    public interface IFixtureRepository
    {
        Task<Fixture> CreateAsync(Fixture fixture);

        Task<Fixture?> DeleteAsync(string? userId, int id);

        Task<List<Fixture>> GetAllAsync(string? userId, FixtureQueryObject query);

        Task<Fixture?> GetByIdAsync(string? userId, int id);

        Task<Fixture?> UpdateAsync(string? userId, int id, Fixture fixture);
    }
}
