using TechProcessSupportSys.Dtos.TechProcess;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Interfaces
{
    public interface IOperationRepository
    {
        Task<Operation> CreateAsync(Operation operation);

        Task<Operation?> DeleteAsync(string? userId, int id);

        Task<List<Operation>> GetAllAsync(string? userId, OperationQueryObject query);

        Task<Operation?> GetByIdAsync(string? userId, int id);

        Task<Operation?> UpdateAsync(string? userId, int id, Operation operation);
    }
}
