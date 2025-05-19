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
            var operation = await context.Operations.Include(o => o.Process).FirstOrDefaultAsync(o => o.Id == id);
            if (operation == null) return null;
            if (userId != null && operation.Process.UserId != userId) return null;

            context.Operations.Remove(operation);
            await context.SaveChangesAsync();

            return operation;
        }

        public async Task<List<Operation>> GetAllAsync(string? userId, OperationQueryObject query)
        {
            var operations = context.Operations.Include(o => o.Process).AsQueryable();

            if (userId != null) operations = operations.Where(o => o.Process.UserId == userId);

            if (query.ProcessId != null) operations = operations.Where(o => o.ProcessId == query.ProcessId);
            if (!string.IsNullOrWhiteSpace(query.Name)) operations = operations.Where(o => o.Name.Contains(query.Name));
            if (query.StepOrder != null) operations = operations.Where(o => o.StepOrder == query.StepOrder);

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name"))
                {
                    operations = query.IsDescending ? operations.OrderByDescending(o => o.Name) : operations.OrderBy(o => o.Name);
                }
                if (query.SortBy.Equals("StepOrder"))
                {
                    operations = query.IsDescending ? operations.OrderByDescending(o => o.StepOrder) : operations.OrderBy(o => o.StepOrder);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await operations.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Operation?> GetByIdAsync(string? userId, int id)
        {
            var operation = await context.Operations.Include(o => o.Process).FirstOrDefaultAsync(o => o.Id == id);

            if (operation == null) return null;
            if (userId != null && operation.Process.UserId != userId) return null;

            return operation;
        }

        public async Task<bool> IsStepOrderDublicate(string? stepOrder)
        {
            return (await context.Operations.AnyAsync(o => o.StepOrder == stepOrder));
        }

        public async Task<Operation?> UpdateAsync(string? userId, int id, Operation operation)
        {
            var existingOperation = await context.Operations.Include(o => o.Process).FirstOrDefaultAsync(o => o.Id == id);

            if (existingOperation == null) return null;
            if (userId != null && existingOperation.Process.UserId != userId) return null;

            existingOperation.Name = operation.Name;
            existingOperation.Description = operation.Description;
            existingOperation.StepOrder = operation.StepOrder; 
            await context.SaveChangesAsync();

            return existingOperation;
        }
    }
}