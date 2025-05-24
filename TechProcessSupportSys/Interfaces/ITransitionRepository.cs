using System.Transactions;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Interfaces
{
    public interface ITransitionRepository
    {
        Task<Transition> CreateAsync(Transition operation);
        int? CreateStepOrder(int id);
        Task<Transition?> DeleteAsync(string? userId, int id);
        Task<List<Transition>?> GetAllAsync(int processId, bool isAdmin, string? userId);
        Task<Transition?> GetByIdAsync(bool isAdmin, string? userId, int id);
        Task<string> GetUserId(int id);
        Task<bool> IsStepOrderDublicate(int id, int? stepOrder);
        Task<bool> IsStepOrderDublicateByTransitionId(int id, int? stepOrder);
        Task<Transition?> UpdateAsync(string? userId, int id, Transition operation);
    }
}
