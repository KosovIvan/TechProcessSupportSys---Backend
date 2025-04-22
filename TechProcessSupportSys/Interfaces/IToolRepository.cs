using TechProcessSupportSys.Data;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Interfaces
{
    public interface IToolRepository
    {
        Task<Tool> CreateAsync(Tool tool);

        Task<Tool?> DeleteAsync(string? userId, int id);

        Task<List<Tool>> GetAllAsync(string? id, ToolQueryObject query);

        Task<Tool?> GetByIdAsync(string? userId, int id);

        Task<Tool?> UpdateAsync(string? userId, int id, Tool tool);
    }
}