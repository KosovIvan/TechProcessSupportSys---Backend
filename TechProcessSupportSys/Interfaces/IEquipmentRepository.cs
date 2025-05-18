using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<Equipment> CreateAsync(Equipment equip);

        Task<Equipment?> DeleteAsync(string? userId, int id);

        Task<List<Equipment>> GetAllAsync(bool isAdmin, string? userId, EquipmentQueryObject query);

        Task<Equipment?> GetByIdAsync(bool isAdmin, string? userId, int id);

        Task<Equipment?> UpdateAsync(string? userId, int id, Equipment equip);
    }
}