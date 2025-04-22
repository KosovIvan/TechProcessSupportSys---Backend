using TechProcessSupportSys.Dtos.TechProcess;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Interfaces
{
    public interface ITechProcessRepository
    {
        Task<TechProcess> CreateAsync(TechProcess process);

        Task<TechProcess?> DeleteAsync(string? userId, int id);

        Task<List<CreateAllDto>> GetAllAsync(string? userId, AllQueryObject query);

        Task<List<TechProcess>> GetProcessesAsync(string? userId, TechProcessQueryObject query);

        Task<TechProcess?> GetByIdAsync(string? userId, int id);

        Task<TechProcess?> UpdateAsync(string? userId, int id, TechProcess process);
    }
}
