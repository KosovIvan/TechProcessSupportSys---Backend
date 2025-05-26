using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Dtos.TechProcess;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<List<TechProcess>> GetProcessesAsync(bool isAdmin, string? userId, TechProcessQueryObject query)
        {
            var processes = context.Processes.Include(p => p.User).AsQueryable();

            if (!isAdmin) processes = processes.Where(p => p.User.RevokedOn == null);

            if (query.IsPrivate) processes = processes.Where(p => p.IsPrivate == true);

            if (!query.IsGlobal)
            {
                processes = processes.Where(p => (p.UserId == userId) && (!string.IsNullOrWhiteSpace(userId)));
            }
            else
            {
                if (!isAdmin)
                {
                    processes = processes.Where(p => !((p.IsPrivate == true) && ((p.UserId != userId) || (string.IsNullOrWhiteSpace(userId)))));
                }
            }

            if (!string.IsNullOrWhiteSpace(query.Name)) processes = processes.Where(p => p.Name.Contains(query.Name));
            if (!string.IsNullOrWhiteSpace(query.Code)) processes = processes.Where(p => p.Code.Contains(query.Code));

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name"))
                {
                    processes = query.IsDescending ? processes.OrderByDescending(p => p.Name) : processes.OrderBy(p => p.Name);
                }
                if (query.SortBy.Equals("Code"))
                {
                    processes = query.IsDescending ? processes.OrderByDescending(p => p.Code) : processes.OrderBy(p => p.Code);
                }
                if (query.SortBy.Equals("ProductName"))
                {
                    processes = query.IsDescending ? processes.OrderByDescending(p => p.ProductName) : processes.OrderBy(p => p.ProductName);
                }
            }

            if (query.IsExpanded)
            {
                processes = processes.
                    Include(p => p.Blank).
                        ThenInclude(b => b.User).
                    Include(p => p.Operations).
                        ThenInclude(o => o.Transitions).
                            ThenInclude(t => t.Tool).
                                ThenInclude(t => t.User).
                    Include(p => p.Operations).
                        ThenInclude(o => o.Transitions).
                            ThenInclude(t => t.Equipment).
                                ThenInclude(e => e.User).
                    Include(p => p.Operations).
                        ThenInclude(o => o.Transitions).
                            ThenInclude(t => t.Fixture).
                                ThenInclude(f => f.User);

                foreach (var process in processes)
                {
                    if (process.Blank?.User?.RevokedOn != null)
                        process.Blank = null;

                    foreach (var operation in process.Operations)
                    {
                        foreach (var transition in operation.Transitions)
                        {
                            if (transition.Tool?.User?.RevokedOn != null)
                                transition.Tool = null;

                            if (transition.Equipment?.User?.RevokedOn != null)
                                transition.Equipment = null;

                            if (transition.Fixture?.User?.RevokedOn != null)
                                transition.Fixture = null;
                        }
                    }
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await processes.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<TechProcess?> GetByIdAsync(bool isAdmin, bool isExpanded, string? userId, int id)
        {
            var processes = context.Processes.Include(p => p.User).AsQueryable();

            if (isExpanded)
            {
                processes = context.Processes.
                    Include(p => p.Blank).
                        ThenInclude(b => b.User).
                    Include(p => p.Operations).
                        ThenInclude(o => o.Transitions).
                            ThenInclude(t => t.Tool).
                                ThenInclude(t => t.User).
                    Include(p => p.Operations).
                        ThenInclude(o => o.Transitions).
                            ThenInclude(t => t.Equipment).
                                ThenInclude(e => e.User).
                    Include(p => p.Operations).
                        ThenInclude(o => o.Transitions).
                            ThenInclude(t => t.Fixture).
                                ThenInclude(f => f.User);
            }
            if (!isAdmin) processes = processes.Where(p => !((p.IsPrivate == true) && ((p.UserId != userId) || (string.IsNullOrWhiteSpace(userId))) || (p.User.RevokedOn != null)));
            var process = await processes.FirstOrDefaultAsync(p => p.Id == id);

            if (process == null) return null;

            if (isExpanded)
            {
                if (process.Blank?.User?.RevokedOn != null)
                    process.Blank = null;

                foreach (var operation in process.Operations)
                {
                    foreach (var transition in operation.Transitions)
                    {
                        if (transition.Tool?.User?.RevokedOn != null)
                            transition.Tool = null;

                        if (transition.Equipment?.User?.RevokedOn != null)
                            transition.Equipment = null;

                        if (transition.Fixture?.User?.RevokedOn != null)
                            transition.Fixture = null;
                    }
                }
            }

            return process;
        }

        public async Task<TechProcess?> UpdateAsync(string? userId, int id, TechProcess process)
        {
            var existingProcess = await context.Processes.Include(p => p.Blank).FirstOrDefaultAsync(p => p.Id == id);

            if (existingProcess == null) return null;
            if (userId != null && existingProcess.UserId != userId) return null;
            if (!((process.Code == existingProcess.Code) || (string.IsNullOrEmpty(process.Code))))
            {
                if (await IsCodeDublicate(process.Code)) return null;
                existingProcess.Code = process.Code;
            }

            existingProcess.Name = process.Name;
            existingProcess.ProductName = process.ProductName;
            existingProcess.Description = process.Description;
            existingProcess.UpdatedAt = process.UpdatedAt;
            existingProcess.UpdatedBy = process.UpdatedBy;
            existingProcess.IsPrivate = process.IsPrivate;
            if (process.BlankId != null) existingProcess.BlankId = process.BlankId;
            await context.SaveChangesAsync();

            return existingProcess;
        }

        public async Task<bool> IsCodeDublicate(string code)
        {
            return await context.Processes.AnyAsync(o => o.Code == code);
        }

        public async Task<bool> IsCodeDublicateWithId(int id, string code)
        {
            var process = await context.Processes.FirstOrDefaultAsync(p => p.Id == id);
            if (process == null) return false;
            if (process.Code == code) return false;
            return await context.Processes.AnyAsync(o => o.Code == code);
        }

        public async Task<TechProcess?> CreateCopy(bool isAdmin, string userId, int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) return null;
            var username = user.UserName;

            var processes = context.Processes.AsQueryable();
            processes = processes.Include(p => p.User).
                Include(p => p.Blank).
                Include(p => p.Operations).
                    ThenInclude(o => o.Transitions).
                        ThenInclude(t => t.Tool).
                    Include(p => p.Operations)
                        .ThenInclude(o => o.Transitions)
                            .ThenInclude(t => t.Equipment)
                    .Include(p => p.Operations)
                        .ThenInclude(o => o.Transitions)
                            .ThenInclude(t => t.Fixture);
            var process = await processes.FirstOrDefaultAsync(p => p.Id == id);

            if (process == null || (process.UserId != userId && process.IsPrivate)) return null;

            var copy = new TechProcess();

            copy.Code = "";
            copy.UserId = userId;
            copy.Name = process.Name;
            copy.ProductName = process.ProductName;
            copy.Description = process.Description;
            copy.Author = username;
            copy.UpdatedBy = username;
            copy.IsPrivate = process.IsPrivate;
            copy.BlankId = process.BlankId;

            foreach (var operation in process.Operations)
            {
                if (isAdmin || !operation.IsPrivate || userId == copy.UserId)
                {
                    var copyOp = new Operation();

                    copyOp.Name = operation.Name;
                    copyOp.StepOrder = operation.StepOrder;
                    copyOp.Duration = operation.Duration;
                    copyOp.Description = operation.Description;
                    copyOp.Author = username;
                    copyOp.UpdatedBy = username;
                    copyOp.IsPrivate = operation.IsPrivate;

                    copy.Operations.Add(copyOp);

                    foreach (var transition in operation.Transitions)
                    {
                        if (isAdmin || !operation.IsPrivate || userId == copy.UserId)
                        {
                            var copyTr = new Transition();

                            copyTr.Name = transition.Name;
                            copyTr.StepOrder = transition.StepOrder;
                            copyTr.Duration = transition.Duration;
                            copyTr.Description = transition.Description;
                            copy.Author = username;
                            copy.UpdatedBy = username;
                            copyTr.IsPrivate = transition.IsPrivate;
                            copyTr.ToolId = transition.ToolId;
                            copyTr.EquipmentId = transition.EquipmentId;
                            copyTr.FixtureId = transition.FixtureId;

                            copyOp.Transitions.Add(copyTr);
                        }
                    }
                }
            }

            await context.AddRangeAsync(copy);
            await context.SaveChangesAsync();

            return copy;
        }
    }
}