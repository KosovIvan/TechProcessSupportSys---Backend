using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<Equipment> CreateAsync(Equipment equip);

        Task<Equipment?> DeleteAsync(int id);

        Task<List<Equipment>> GetAllAsync(EquipmentQueryObject query);

        Task<Equipment?> GetByIdAsync(int id);

        Task<Equipment?> UpdateAsync(int id, Equipment equip);
    }
}