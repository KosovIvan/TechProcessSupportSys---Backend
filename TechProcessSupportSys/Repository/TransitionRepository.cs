using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TechProcessSupportSys.Data;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Repository
{
    public class TransitionRepository : ITransitionRepository
    {
        private readonly ApplicationDbContext context;

        public TransitionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Transition> CreateAsync(Transition transition)
        {
            await context.Transitions.AddAsync(transition);
            await context.SaveChangesAsync();

            return transition;
        }

        public int? CreateStepOrder(int id)
        {
            int num = 0;
            var numbers = context.Transitions.Where(t => t.OperationId == id).AsEnumerable().Select(o => o.StepOrder).OrderBy(n => n).ToList();
            if (numbers.Count == 0) num = 1;
            else if (numbers.Count < 60)
            {
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
                return num;
            }
            return null;
        }

        public async Task<Transition?> DeleteAsync(string? userId, int id)
        {
            var transition = await context.Transitions.FirstOrDefaultAsync(t => t.Id == id);
            if (transition == null) return null;
            if (userId != null && transition.Operation.Process.UserId != userId) return null;

            context.Transitions.Remove(transition);
            await context.SaveChangesAsync();

            return transition;
        }

        public async Task<List<Transition>?> GetAllAsync(int operationId, bool isAdmin, string? userId)
        {
            var operation = await context.Operations.Include(o => o.Process).FirstOrDefaultAsync(o => o.Id == operationId);
            if (operation == null) return null;

            var process = operation.Process;
            var processUserId = process.UserId;
            var operationIsPrivate = operation.IsPrivate;

            var transitions = context.Transitions.Include(t => t.Operation).ThenInclude(o => o.Process).ThenInclude(p => p.User).AsQueryable().Where(t => t.OperationId == operationId);

            if (!isAdmin) transitions = transitions.Where(t => t.Operation.Process.User.RevokedOn == null);

            if (!((processUserId != userId) && (operationIsPrivate)) || (isAdmin))
            {
                if (!isAdmin)
                {
                    transitions = transitions.Where(t => !((t.IsPrivate == true) && ((processUserId != userId) || (string.IsNullOrWhiteSpace(userId)))));
                }

                return await transitions.OrderBy(t => t.StepOrder).ToListAsync();
            }

            return null;
        }

        public async Task<Transition?> GetByIdAsync(bool isAdmin, string? userId, int id)
        {
            var transitions = context.Transitions.Include(t => t.Operation).ThenInclude(o => o.Process).ThenInclude(p => p.User).AsQueryable();
            if (!isAdmin) transitions = transitions.Where(t => !((t.IsPrivate == true) && ((t.Operation.Process.UserId != userId) || (string.IsNullOrWhiteSpace(userId))) || (t.Operation.Process.User.RevokedOn != null)));
            var transition = await transitions.FirstOrDefaultAsync(t => t.Id == id);

            if (transition == null) return null;

            return transition;
        }

        public async Task<string> GetUserId(int id)
        {
            var operations = context.Operations.AsQueryable().Include(o => o.Process);
            return (await operations.FirstOrDefaultAsync(o => o.Id == id)).Process.UserId;
        }

        public async Task<bool> IsStepOrderDublicate(int id, int? stepOrder)
        {
            return await context.Transitions.Where(t => t.OperationId == id).AnyAsync(t => t.StepOrder == stepOrder);
        }

        public async Task<bool> IsStepOrderDublicateByTransitionId(int id, int? stepOrder)
        {
            var transition = await context.Transitions.FirstOrDefaultAsync(t => t.Id == id);
            if (transition == null) return false;
            return await context.Transitions.Where(t => t.OperationId == transition.OperationId).AnyAsync(t => t.StepOrder == stepOrder);
        }

        public async Task<Transition?> UpdateAsync(string? userId, int id, Transition transition)
        {
            var existingTransition = await context.Transitions.FirstOrDefaultAsync(o => o.Id == id);

            if (existingTransition == null) return null;
            if (userId != null && existingTransition.Operation.Process.UserId != userId) return null;
            if (!((transition.StepOrder == existingTransition.StepOrder) || (transition.StepOrder == 0) || (transition.StepOrder == null))) existingTransition.StepOrder = transition.StepOrder;

            existingTransition.Name = transition.Name;
            existingTransition.Duration = transition.Duration;
            existingTransition.Description = transition.Description;
            existingTransition.UpdatedAt = transition.UpdatedAt;
            existingTransition.UpdatedBy = transition.UpdatedBy;
            existingTransition.IsPrivate = transition.IsPrivate;
            existingTransition.ToolId = transition.ToolId;
            existingTransition.EquipmentId = transition.EquipmentId;
            existingTransition.FixtureId = transition.FixtureId;
            await context.SaveChangesAsync();

            return existingTransition;
        }
    }
}