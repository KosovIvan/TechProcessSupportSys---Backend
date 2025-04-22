using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Dtos.TechProcess;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Repository
{
    public class TechProcessRepository : ITechProcessRepository
    {
        private readonly ApplicationDbContext context;

        public TechProcessRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<TechProcess> CreateAsync(TechProcess process)
        {
            await context.Processes.AddAsync(process);
            await context.SaveChangesAsync();

            return process;
        }

        public async Task<TechProcess?> DeleteAsync(string? userId, int id)
        {
            var process = await context.Processes.FirstOrDefaultAsync(p => p.Id == id);

            if (process == null) return null;
            if (userId != null && process.UserId != userId) return null;

            context.Processes.Remove(process);
            await context.SaveChangesAsync();

            return process;
        }

        public async Task<List<TechProcess>> GetProcessesAsync(string? userId, TechProcessQueryObject query)
        {
            var processes = context.Processes.AsQueryable();

            if (userId != null) processes = processes.Where(p => p.UserId == userId);

            if (!string.IsNullOrWhiteSpace(query.Name)) processes = processes.Where(p => p.Name.Contains(query.Name));

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name"))
                {
                    processes = query.IsDescending ? processes.OrderByDescending(p => p.Name) : processes.OrderBy(p => p.Name);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await processes.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<TechProcess?> GetByIdAsync(string? userId, int id)
        {
            var process = await context.Processes.FirstOrDefaultAsync(p => p.Id == id);

            if (process == null) return null;
            if (userId != null && process.UserId != userId) return null;

            return process;
        }

        public async Task<TechProcess?> UpdateAsync(string? userId, int id, TechProcess process)
        {
            var existingProcess = await context.Processes.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProcess == null) return null;
            if (userId != null && existingProcess.UserId != userId) return null;

            existingProcess.Name = process.Name;
            existingProcess.Description = process.Description;
            await context.SaveChangesAsync();

            return existingProcess;
        }

        public async Task<List<CreateAllDto>> GetAllAsync(string? userId, AllQueryObject query)
        {
            var processes = (from process in context.Processes

                        join operation in context.Operations
                            on process.Id equals operation.ProcessId into operations
                        from operation in operations.DefaultIfEmpty()

                        join transition in context.Transitions
                            on operation.Id equals transition.OperationId into transitions
                        from transition in transitions.DefaultIfEmpty()

                        join tool in context.Tools
                            on transition.ToolId equals tool.Id into tools
                        from tool in tools.DefaultIfEmpty()

                        join equip in context.Equipment
                            on transition.EquipmentId equals equip.Id into equipment
                        from equip in equipment.DefaultIfEmpty()

                        join fixture in context.Fixtures
                            on transition.FixtureId equals fixture.Id into fixtures
                        from fixture in fixtures.DefaultIfEmpty()

                        select new CreateAllDto
                        {
                            Id = process.Id,
                            UserId = process.UserId,
                            ProcessName = process.Name,
                            OperationName = operation != null ? operation.Name : null,
                            TransitionName = transition != null ? transition.Name : null,
                            ToolName = tool != null ? tool.Name : null,
                            EquipmentName = equip != null ? equip.Name : null,
                            FixtureName = fixture != null ? fixture.Name : null
                        }).AsQueryable();

            if (userId != null) processes = processes.Where(p => p.UserId == userId);

            if (!string.IsNullOrWhiteSpace(query.ProcessName)) processes = processes.Where(p => p.ProcessName.Contains(query.ProcessName));
            if (!string.IsNullOrWhiteSpace(query.OperationName)) processes = processes.Where(p => p.OperationName.Contains(query.OperationName));
            if (!string.IsNullOrWhiteSpace(query.TransitionName)) processes = processes.Where(p => p.TransitionName.Contains(query.TransitionName));
            if (!string.IsNullOrWhiteSpace(query.ToolName)) processes = processes.Where(p => p.ToolName.Contains(query.ToolName));
            if (!string.IsNullOrWhiteSpace(query.EquipmentName)) processes = processes.Where(p => p.EquipmentName.Contains(query.EquipmentName));
            if (!string.IsNullOrWhiteSpace(query.FixtureName)) processes = processes.Where(p => p.FixtureName.Contains(query.FixtureName));

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("ProcessName"))
                {
                    processes = query.IsDescending ? processes.OrderByDescending(p => p.ProcessName) : processes.OrderBy(p => p.ProcessName);
                }
                if (query.SortBy.Equals("OperationName"))
                {
                    processes = query.IsDescending ? processes.OrderByDescending(p => p.OperationName) : processes.OrderBy(p => p.OperationName);
                }
                if (query.SortBy.Equals("TransitionName"))
                {
                    processes = query.IsDescending ? processes.OrderByDescending(p => p.TransitionName) : processes.OrderBy(p => p.TransitionName);
                }
                if (query.SortBy.Equals("ToolName"))
                {
                    processes = query.IsDescending ? processes.OrderByDescending(p => p.ToolName) : processes.OrderBy(p => p.ToolName);
                }
                if (query.SortBy.Equals("EquipmentName"))
                {
                    processes = query.IsDescending ? processes.OrderByDescending(p => p.EquipmentName) : processes.OrderBy(p => p.EquipmentName);
                }
                if (query.SortBy.Equals("FixtureName"))
                {
                    processes = query.IsDescending ? processes.OrderByDescending(p => p.FixtureName) : processes.OrderBy(p => p.FixtureName);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await processes.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }
    }
}