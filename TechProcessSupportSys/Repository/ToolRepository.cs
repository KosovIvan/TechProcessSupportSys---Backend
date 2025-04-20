using Microsoft.EntityFrameworkCore;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Repository
{
    public class ToolRepository : IToolRepository
    {
        private readonly ApplicationDbContext context;

        public ToolRepository(ApplicationDbContext context) { 
            this.context = context;
        }

        public async Task<Tool> CreateAsync(Tool tool)
        {
            await context.Tools.AddAsync(tool);
            await context.SaveChangesAsync();

            return tool;
        }

        public async Task<Tool?> DeleteAsync(int id)
        {
            var tool = await context.Tools.FirstOrDefaultAsync(t => t.Id == id);

            if (tool == null) return null;

            context.Tools.Remove(tool);
            await context.SaveChangesAsync();

            return tool;
        }

        public async Task<List<Tool>> GetAllAsync()
        {
            return await context.Tools.ToListAsync();
        }

        public async Task<Tool?> GetByIdAsync(int id)
        {
            return await context.Tools.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tool?> UpdateAsync(int id, Tool tool)
        {
            var existingTool = await context.Tools.FirstOrDefaultAsync(t => t.Id == id);

            if (existingTool == null)
            {
                return null;
            }

            existingTool.Name = tool.Name;
            existingTool.Description = tool.Description;
            existingTool.Type = tool.Type;
            existingTool.Material = tool.Material;
            await context.SaveChangesAsync();

            return existingTool;
        }
    }
}
