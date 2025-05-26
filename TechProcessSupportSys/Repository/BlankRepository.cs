using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Repository
{
    public class BlankRepository : IBlankRepository
    {
        private readonly ApplicationDbContext context;

        public BlankRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Blank> CreateAsync(Blank blank)
        {
            await context.Blanks.AddAsync(blank);
            await context.SaveChangesAsync();

            return blank;
        }

        public async Task<Blank?> DeleteAsync(string? userId, int id)
        {
            var blank = await context.Blanks.FirstOrDefaultAsync(b => b.Id == id);

            if (blank == null) return null;
            if (userId != null && blank.UserId != userId) return null;

            context.Blanks.Remove(blank);
            await context.SaveChangesAsync();

            return blank;
        }

        public async Task<List<Blank>> GetAllAsync(bool isAdmin, string? userId, BlankQueryObject query)
        {
            var blanks = context.Blanks.Include(b => b.User).AsQueryable();

            if (!isAdmin) blanks = blanks.Where(b => b.User.RevokedOn == null);

            if (query.IsPrivate) blanks = blanks.Where(b => b.IsPrivate == true);

            if (!query.IsGlobal)
            {
                blanks = blanks.Where(b => (b.UserId == userId) && (!string.IsNullOrWhiteSpace(userId)));
            }
            else
            {
                if (!isAdmin)
                {
                    blanks = blanks.Where(b => !((b.IsPrivate == true) && ((b.UserId != userId) || (string.IsNullOrWhiteSpace(userId)))));
                }
            }

            if (!string.IsNullOrWhiteSpace(query.Asortment)) blanks = blanks.Where(b => b.Asortment.Contains(query.Asortment));

            if (!string.IsNullOrWhiteSpace(query.Material)) blanks = blanks.Where(b => b.Material.Contains(query.Material));

            if (!string.IsNullOrWhiteSpace(query.GOST)) blanks = blanks.Where(b => b.MaterialGOST.Contains(query.GOST) || b.AsortmentGOST.Contains(query.GOST));

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Asortment"))
                {
                    blanks = query.IsDescending ? blanks.OrderByDescending(b => b.Asortment) : blanks.OrderBy(b => b.Asortment);
                }
                if (query.SortBy.Equals("Material"))
                {
                    blanks = query.IsDescending ? blanks.OrderByDescending(b => b.Material) : blanks.OrderBy(b => b.Material);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await blanks.Skip(skipNumber).Take(query.PageSize).ToListAsync();

        }

        public async Task<Blank?> GetByIdAsync(bool isAdmin, string? userId, int id)
        {
            var blanks = context.Blanks.Include(b => b.User).AsQueryable();
            if (!isAdmin) blanks = blanks.Where(b => !((b.IsPrivate == true) && ((b.UserId != userId) || (string.IsNullOrWhiteSpace(userId))) || (b.User.RevokedOn != null)));
            var blank = await blanks.FirstOrDefaultAsync(b => b.Id == id);

            if (blank == null) return null;

            return blank;
        }

        public async Task<Blank?> UpdateAsync(string? userId, int id, Blank blank)
        {
            var existingBlank = await context.Blanks.FirstOrDefaultAsync(b => b.Id == id);

            if (existingBlank == null) return null;
            if (userId != null && existingBlank.UserId != userId) return null;

            existingBlank.Asortment = blank.Asortment;
            if (blank.AsortmentGOST != null) existingBlank.AsortmentGOST = blank.AsortmentGOST;
            existingBlank.Material = blank.Material;
            if (blank.MaterialGOST != null) existingBlank.MaterialGOST = blank.MaterialGOST;
            if (blank.MaterialStateCode != null) existingBlank.MaterialStateCode = blank.MaterialStateCode;
            existingBlank.Length = blank.Length;
            if (blank.Width != null) existingBlank.Width = blank.Width;
            if (blank.Height != null) existingBlank.Height = blank.Height;
            if (blank.Diameter != null) existingBlank.Diameter = blank.Diameter;
            existingBlank.UpdatedAt = blank.UpdatedAt;
            existingBlank.UpdatedBy = blank.UpdatedBy;
            existingBlank.IsPrivate = blank.IsPrivate;
            await context.SaveChangesAsync();

            return existingBlank;
        }
    }
}