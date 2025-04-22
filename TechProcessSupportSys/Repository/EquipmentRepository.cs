using Microsoft.EntityFrameworkCore;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

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

        public async Task<Equipment?> DeleteAsync(string? userId, int id)
        {
            var equip = await context.Equipment.FirstOrDefaultAsync(e => e.Id == id);

            if (equip == null) return null;
            if (userId != null && equip.UserId != userId) return null;

            context.Equipment.Remove(equip);
            await context.SaveChangesAsync();

            return equip;
        }

        public async Task<List<Equipment>> GetAllAsync(string? userId, EquipmentQueryObject query)
        {
            var equip = context.Equipment.AsQueryable();

            if (userId != null) equip = equip.Where(e => e.UserId == userId);

            if (!string.IsNullOrWhiteSpace(query.Name)) equip = equip.Where(e => e.Name.Contains(query.Name));

            if (!string.IsNullOrWhiteSpace(query.Model)) equip = equip.Where(e => e.Model.Contains(query.Model));

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name"))
                {
                    equip = query.IsDescending ? equip.OrderByDescending(e => e.Name) : equip.OrderBy(e => e.Name);
                }
                if (query.SortBy.Equals("Model"))
                {
                    equip = query.IsDescending ? equip.OrderByDescending(e => e.Model) : equip.OrderBy(e => e.Model);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await equip.Skip(skipNumber).Take(query.PageSize).ToListAsync();

        }

        public async Task<Equipment?> GetByIdAsync(string? userId, int id)
        {
            var equip = await context.Equipment.FirstOrDefaultAsync(e => e.Id == id);

            if (equip == null) return null;
            if (userId != null && equip.UserId != userId) return null;

            return equip;
        }

        public async Task<Equipment?> UpdateAsync(string? userId, int id, Equipment equip)
        {
            var existingEquip = await context.Equipment.FirstOrDefaultAsync(e => e.Id == id);

            if (existingEquip == null) return null;
            if (userId != null && existingEquip.UserId != userId) return null;

            existingEquip.Name = equip.Name;
            existingEquip.Description = equip.Description;
            existingEquip.Model = equip.Model;
            await context.SaveChangesAsync();

            return existingEquip;
        }
    }
}
