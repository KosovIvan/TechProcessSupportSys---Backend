using Microsoft.EntityFrameworkCore;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ApplicationDbContext context;

        public EquipmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Equipment> CreateAsync(Equipment equip)
        {
            await context.Equipment.AddAsync(equip);
            await context.SaveChangesAsync();

            return equip;
        }

        public async Task<Equipment?> DeleteAsync(int id)
        {
            var equip = await context.Equipment.FirstOrDefaultAsync(e => e.Id == id);

            if (equip == null) return null;

            context.Equipment.Remove(equip);
            await context.SaveChangesAsync();

            return equip;
        }

        public async Task<List<Equipment>> GetAllAsync()
        {
            return await context.Equipment.ToListAsync();
        }

        public async Task<Equipment?> GetByIdAsync(int id)
        {
            return await context.Equipment.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Equipment?> UpdateAsync(int id, Equipment equip)
        {
            var existingEquip = await context.Equipment.FirstOrDefaultAsync(e => e.Id == id);

            if (existingEquip == null)
            {
                return null;
            }

            existingEquip.Name = equip.Name;
            existingEquip.Description = equip.Description;
            existingEquip.Model = equip.Model;
            await context.SaveChangesAsync();

            return existingEquip;
        }
    }
}
