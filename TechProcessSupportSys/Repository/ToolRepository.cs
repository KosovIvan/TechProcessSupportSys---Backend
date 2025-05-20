using Microsoft.EntityFrameworkCore;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

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

        public async Task<Tool?> DeleteAsync(string? userId, int id)
        {
            var tool = await context.Tools.FirstOrDefaultAsync(t => t.Id == id);

            if (tool == null) return null;
            if (userId != null && tool.UserId != userId) return null;

            context.Tools.Remove(tool);
            await context.SaveChangesAsync();

            return tool;
        }

        public async Task<List<Tool>> GetAllAsync(bool isAdmin, string? userId, ToolQueryObject query)
        {
            var tools = context.Tools.AsQueryable();

            if (query.IsPrivate) tools = tools.Where(t => t.IsPrivate == true);

            if (!query.IsGlobal)
            {
                tools = tools.Where(t => (t.UserId == userId)&&(!string.IsNullOrWhiteSpace(userId)));
            }
            else
            {
                if (!isAdmin)
                {
                    tools = tools.Where(t => !((t.IsPrivate == true) && ((t.UserId != userId) || (string.IsNullOrWhiteSpace(userId)))));
                }
            }
            
            if (!string.IsNullOrWhiteSpace(query.Name)) tools = tools.Where(t => t.Name.Contains(query.Name));

            if (!string.IsNullOrWhiteSpace(query.Type)) tools = tools.Where(t => t.Type.Contains(query.Type));

            if (!string.IsNullOrWhiteSpace(query.GOST)) tools = tools.Where(t => t.GOST.Contains(query.GOST));

            if (!string.IsNullOrWhiteSpace(query.Material)) tools = tools.Where(t => t.Material.Contains(query.Material));

            if (!string.IsNullOrWhiteSpace(query.SortBy)) {
                if (query.SortBy.Equals("Name"))
                {
                    tools = query.IsDescending ? tools.OrderByDescending(t => t.Name) : tools.OrderBy(t => t.Name);
                }
                if (query.SortBy.Equals("Type"))
                {
                    tools = query.IsDescending ? tools.OrderByDescending(t => t.Type) : tools.OrderBy(t => t.Type);
                }
                if (query.SortBy.Equals("Material"))
                {
                    tools = query.IsDescending ? tools.OrderByDescending(t => t.Material) : tools.OrderBy(t => t.Material);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await tools.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Tool?> GetByIdAsync(bool isAdmin, string? userId, int id)
        {
            var tools = context.Tools.AsQueryable();
            if (!isAdmin) tools = tools.Where(t => !((t.IsPrivate == true) && ((t.UserId != userId) || (string.IsNullOrWhiteSpace(userId)))));
            var tool = await tools.FirstOrDefaultAsync(t => t.Id == id);

            if (tool == null) return null;

            return tool;
        }

        public async Task<Tool?> UpdateAsync(string? userId, int id, Tool tool)
        {

            var existingTool = await context.Tools.FirstOrDefaultAsync(t => t.Id == id);

            if (existingTool == null) return null;
            if (userId != null && existingTool.UserId != userId) return null;

            existingTool.Name = tool.Name;
            existingTool.Description = tool.Description;
            existingTool.Type = tool.Type;
            existingTool.Material = tool.Material;
            existingTool.GOST = tool.GOST;
            await context.SaveChangesAsync();

            return existingTool;
        }
    }
}