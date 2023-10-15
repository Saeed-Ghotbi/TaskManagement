using Microsoft.EntityFrameworkCore;
using TaskManagement.Context;
using TaskManagement.Contracts.Repository;
using Task = TaskManagement.Model.Task;

namespace TaskManagement.Repository
{
    public class TaskRepository : GenericRepository<Model.Task>, ITaskRepository
    {
        private readonly TaskManagementContext _context;
        public TaskRepository(TaskManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Task>> GetAllTasks()
        {
            return await _context.Task.Include(t => t.Assignment)
                .Include(t => t.Status)
                .Include(t => t.Subject)
                .OrderBy(t => t.CDT)
                .ToListAsync();
        }

        public async Task<Task> GetTaskById(int id)
        {
            return await _context.Task.Where(t=>t.Id == id)
                .Include(t => t.Assignment)
                .Include(t => t.Status)
                .Include(t => t.Subject)
                .SingleOrDefaultAsync();
        }
    }
}
