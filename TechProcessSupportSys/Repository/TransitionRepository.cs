using TechProcessSupportSys.Data;
using TechProcessSupportSys.Interfaces;

namespace TechProcessSupportSys.Repository
{
    public class TransitionRepository : ITransitionRepository
    {
        private readonly ApplicationDbContext context;

        public TransitionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


    }
}