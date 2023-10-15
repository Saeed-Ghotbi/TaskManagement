using TaskManagement.Context;
using TaskManagement.Contracts.Repository;
using TaskManagement.Model;

namespace TaskManagement.Repository
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        private readonly TaskManagementContext _context;

        public StatusRepository(TaskManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
