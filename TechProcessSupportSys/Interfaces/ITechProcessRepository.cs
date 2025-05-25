using TechProcessSupportSys.Dtos.TechProcess;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Interfaces
{
    public interface ITechProcessRepository
    {
        Task<TechProcess> CreateAsync(TechProcess process);

        Task<TechProcess?> DeleteAsync(string? userId, int id);

        Task<List<TechProcess>> GetProcessesAsync(bool isAdmin, string? userId, TechProcessQueryObject query);

        Task<TechProcess?> GetByIdAsync(bool isAdmin, bool isExpanded, string? userId, int id);

        Task<TechProcess?> UpdateAsync(string? userId, int id, TechProcess process);
        Task<bool> IsCodeDublicate(string code);
        Task<TechProcess?> CreateCopy(bool isAdmin, string userId, int id);
        Task<bool> IsCodeDublicateWithId(int id, string code);
    }
}
