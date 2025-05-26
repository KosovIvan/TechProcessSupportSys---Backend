using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Repository
{
    public class OperationRepository : IOperationRepository
    {
        private readonly ApplicationDbContext context;

        public OperationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Operation> CreateAsync(Operation operation)
        {
            await context.Operations.AddAsync(operation);
            await context.SaveChangesAsync();

            return operation;
        }

        public async Task<string?> GetUserId(int id)
        {
            return (await context.Processes.FirstOrDefaultAsync(o => o.Id == id)).UserId;
        }

        public string? CreateStepOrder(int id)
        {
            int num = 0;
            var numbers = context.Operations.Where(o => !string.IsNullOrWhiteSpace(o.StepOrder) && o.ProcessId == id).AsEnumerable().Select(o => int.Parse(o.StepOrder) / 10).Distinct().OrderBy(n => n).ToList();
            if (numbers.Count == 0) num = 10;
            else if (numbers.Count >= 99)
            {
                numbers = context.Operations.Where(o => !string.IsNullOrWhiteSpace(o.StepOrder) && o.ProcessId == id).AsEnumerable().Select(o => int.Parse(o.StepOrder)).OrderBy(n => n).ToList();
                if (numbers.Count >= 999) return null;
                numbers.Insert(0, 0);
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i + 1 < numbers.Count)
                    {
                        if (numbers[i + 1] - numbers[i] > 1)
                        {
                            num = numbers[i] + 1;
                            break;
                        }
                    }
                }
                numbers.Remove(0);
                if (num == 0) num = numbers.Max(n => n) + 1;
                switch (num)
                {
                    case >= 100: return num.ToString();
                    case >= 10: return "0" + num.ToString();
                    default: return "00" + num.ToString();
                }
            }
            else
            {
                numbers.Insert(0, 0);
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i + 1 < numbers.Count) {
                        if (numbers[i + 1] - numbers[i] > 1)
                        {
                            num = (numbers[i] + 1) * 10;
                            break;
                        }
                    }
                }
                numbers.Remove(0);
                if (num == 0) num = (numbers.Max(n => n) + 1) * 10;
            }

            return num >= 100 ? num.ToString() : "0" + num.ToString();
        }

        public async Task<Operation?> DeleteAsync(string? userId, int id)
        {
            var operation = await context.Operations.FirstOrDefaultAsync(o => o.Id == id);
            if (operation == null) return null;
            if (userId != null && operation.Process.UserId != userId) return null;

            context.Operations.Remove(operation);
            await context.SaveChangesAsync();

            return operation;
        }

        public async Task<List<Operation>?> GetAllAsync(int processId, bool isAdmin, string? userId)
        {
            var process = await context.Processes.FirstOrDefaultAsync(p => p.Id == processId);
            if (process == null) return null;

            var processUserId = process.UserId;
            var processIsPrivate = process.IsPrivate;

            var operations = context.Operations.AsNoTracking().Include(o => o.Process).ThenInclude(p => p.User).AsQueryable().Where(o => o.ProcessId == processId);

            if (!isAdmin) operations = operations.Where(o => o.Process.User.RevokedOn == null);

            if (!((processUserId != userId) && (processIsPrivate)) || (isAdmin))
            {
                if (!isAdmin)
                {
                    operations = operations.Where(o => !((o.IsPrivate == true) && ((processUserId != userId) || (string.IsNullOrWhiteSpace(userId)))));
                }

                return await operations.OrderBy(o => o.StepOrder).ToListAsync();
            }

            return null;
        }

        public async Task<Operation?> GetByIdAsync(bool isAdmin, string? userId, int id)
        {
            var operations = context.Operations.AsNoTracking().Include(o => o.Process).ThenInclude(p => p.User).AsQueryable();
            if (!isAdmin) operations = operations.Where(o => !((o.IsPrivate == true) && ((o.Process.UserId != userId) || (string.IsNullOrWhiteSpace(userId))) || (o.Process.User.RevokedOn != null)));
            var operation = await operations.FirstOrDefaultAsync(o => o.Id == id);

            if (operation == null) return null;

            return operation;
        }

        public async Task<bool> IsStepOrderDublicate(int id, string? stepOrder)
        {
            return await context.Operations.Where(o => o.ProcessId == id).AnyAsync(o => o.StepOrder == stepOrder);
        }

        public async Task<bool> IsStepOrderDublicateByOperationId(int id, string? stepOrder)
        {
            var operation = await context.Operations.FirstOrDefaultAsync(o => o.Id == id);
            if (operation == null) return false;
            if (operation.StepOrder == stepOrder) return false;
            return await context.Operations.Where(o => o.ProcessId == operation.ProcessId).AnyAsync(o => o.StepOrder == stepOrder);
        }

        public async Task<Operation?> UpdateAsync(string? userId, int id, Operation operation)
        {
            var existingOperation = await context.Operations.FirstOrDefaultAsync(o => o.Id == id);

            if (existingOperation == null) return null;
            if (userId != null && existingOperation.Process.UserId != userId) return null;
            if (!((operation.StepOrder == existingOperation.StepOrder) || (string.IsNullOrEmpty(operation.StepOrder)))) existingOperation.StepOrder = operation.StepOrder;

            existingOperation.Name = operation.Name;
            existingOperation.Duration = operation.Duration;
            existingOperation.Description = operation.Description;
            existingOperation.UpdatedAt = operation.UpdatedAt;
            existingOperation.UpdatedBy = operation.UpdatedBy;
            existingOperation.IsPrivate = operation.IsPrivate;
            await context.SaveChangesAsync();

            return existingOperation;
        }
    }
}