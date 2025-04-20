using TechProcessSupportSys.Data;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Interfaces
{
    public interface IToolRepository
    {
        Task<Tool> CreateAsync(Tool tool);

        Task<Tool?> DeleteAsync(int id);

        Task<List<Tool>> GetAllAsync();

        Task<Tool?> GetByIdAsync(int id);

        Task<Tool?> UpdateAsync(int id, Tool tool);
    }
}