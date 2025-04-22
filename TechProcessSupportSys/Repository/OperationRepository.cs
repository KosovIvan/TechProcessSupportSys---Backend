using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
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