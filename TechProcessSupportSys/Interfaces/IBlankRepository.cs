using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Interfaces
{
    public interface IBlankRepository
    {
        Task<Blank> CreateAsync(Blank blank);

        Task<Blank?> DeleteAsync(string? userId, int id);

        Task<List<Blank>> GetAllAsync(bool isAdmin, string? userId, BlankQueryObject query);

        Task<Blank?> GetByIdAsync(bool isAdmin, string? userId, int id);

        Task<Blank?> UpdateAsync(string? userId, int id, Blank blank);
    }
}