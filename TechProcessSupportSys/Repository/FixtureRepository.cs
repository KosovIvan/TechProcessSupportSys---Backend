using Microsoft.EntityFrameworkCore;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Repository
{
    public class FixtureRepository : IFixtureRepository
    {
        private readonly ApplicationDbContext context;

        public FixtureRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Fixture> CreateAsync(Fixture fixture)
        {
            await context.Fixtures.AddAsync(fixture);
            await context.SaveChangesAsync();

            return fixture;
        }

        public async Task<Fixture?> DeleteAsync(string? userId, int id)
        {
            var fixture = await context.Fixtures.FirstOrDefaultAsync(f => f.Id == id);

            if (fixture == null) return null;
            if (userId != null && fixture.UserId != userId) return null;

            context.Fixtures.Remove(fixture);
            await context.SaveChangesAsync();

            return fixture;
        }

        public async Task<List<Fixture>> GetAllAsync(string? userId, FixtureQueryObject query)
        {
            var fixtures = context.Fixtures.AsQueryable();

            if (userId != null) fixtures = fixtures.Where(f => f.UserId == userId);

            if (!string.IsNullOrWhiteSpace(query.Name)) fixtures = fixtures.Where(f => f.Name.Contains(query.Name));

            if (!string.IsNullOrWhiteSpace(query.Type)) fixtures = fixtures.Where(f => f.Type.Contains(query.Type));

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name"))
                {
                    fixtures = query.IsDescending ? fixtures.OrderByDescending(f => f.Name) : fixtures.OrderBy(f => f.Name);
                }
                if (query.SortBy.Equals("Type"))
                {
                    fixtures = query.IsDescending ? fixtures.OrderByDescending(f => f.Type) : fixtures.OrderBy(f => f.Type);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await fixtures.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Fixture?> GetByIdAsync(string? userId, int id)
        {
            var fixture = await context.Fixtures.FirstOrDefaultAsync(f => f.Id == id);

            if (fixture == null) return null;
            if (userId != null && fixture.UserId != userId) return null;

            return fixture;
        }

        public async Task<Fixture?> UpdateAsync(string? userId, int id, Fixture fixture)
        {
            var existingFixture = await context.Fixtures.FirstOrDefaultAsync(f => f.Id == id);

            if (existingFixture == null) return null;
            if (userId != null && existingFixture.UserId != userId) return null;

            existingFixture.Name = fixture.Name;
            existingFixture.Description = fixture.Description;
            existingFixture.Type = fixture.Type;
            await context.SaveChangesAsync();

            return existingFixture;
        }
    }
}
