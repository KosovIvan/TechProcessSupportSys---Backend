using Microsoft.EntityFrameworkCore;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;

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

        public async Task<List<Fixture>> GetAllAsync()
        {
            return await context.Fixtures.ToListAsync();
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
