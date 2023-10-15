using TaskManagement.Context;
using TaskManagement.Contracts.Repository;
using TaskManagement.Model;

namespace TaskManagement.Repository
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly TaskManagementContext _context;
        public SubjectRepository(TaskManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
