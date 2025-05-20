using System.Diagnostics;
using TechProcessSupportSys.Dtos.TechProcess;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Interfaces
{
    public interface IOperationRepository
    {
        Task<Operation> CreateAsync(Operation operation);
        string? CreateStepOrder(int id);
        Task<Operation?> DeleteAsync(string? userId, int id);
        Task<List<Operation>?> GetAllAsync(int processId, bool isAdmin, string? userId, OperationQueryObject query);
        Task<Operation?> GetByIdAsync(bool isAdmin, string? userId, int id);
        Task<bool> IsStepOrderDublicate(string? stepOrder);
        Task<Operation?> UpdateAsync(string? userId, int id, Operation operation);
    }
}
