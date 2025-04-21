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

        public async Task<Fixture?> DeleteAsync(int id)
        {
            var fixture = await context.Fixtures.FirstOrDefaultAsync(f => f.Id == id);

            if (fixture == null) return null;

            context.Fixtures.Remove(fixture);
            await context.SaveChangesAsync();

            return fixture;
        }

        public async Task<List<Fixture>> GetAllAsync(FixtureQueryObject query)
        {
            var fixtures = context.Fixtures.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name)) fixtures = fixtures.Where(t => t.Name.Contains(query.Name));

            if (!string.IsNullOrWhiteSpace(query.Type)) fixtures = fixtures.Where(t => t.Type.Contains(query.Type));

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name"))
                {
                    fixtures = query.IsDescending ? fixtures.OrderByDescending(t => t.Name) : fixtures.OrderBy(t => t.Name);
                }
                if (query.SortBy.Equals("Type"))
                {
                    fixtures = query.IsDescending ? fixtures.OrderByDescending(t => t.Type) : fixtures.OrderBy(t => t.Type);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await fixtures.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Fixture?> GetByIdAsync(int id)
        {
            return await context.Fixtures.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fixture?> UpdateAsync(int id, Fixture fixture)
        {
            var existingFixture = await context.Fixtures.FirstOrDefaultAsync(f => f.Id == id);

            if (existingFixture == null)
            {
                return null;
            }

            existingFixture.Name = fixture.Name;
            existingFixture.Description = fixture.Description;
            existingFixture.Type = fixture.Type;
            await context.SaveChangesAsync();

            return existingFixture;
        }
    }
}
