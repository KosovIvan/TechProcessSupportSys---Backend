using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Interfaces
{
    public interface IFixtureRepository
    {
        Task<Fixture> CreateAsync(Fixture fixture);

        Task<Fixture?> DeleteAsync(string? userId, int id);

        Task<List<Fixture>> GetAllAsync(bool isAdmin, string? userId, FixtureQueryObject query);

        Task<Fixture?> GetByIdAsync(bool isAdmin, string? userId, int id);

        Task<Fixture?> UpdateAsync(string? userId, int id, Fixture fixture);
    }
}
