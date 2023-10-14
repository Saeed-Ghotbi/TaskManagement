using Microsoft.EntityFrameworkCore;
using TaskManagement.Context;
using TaskManagement.Contracts.Repository;
using TaskManagement.Model;

namespace TaskManagement.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TaskManagementContext _context;

        public UserRepository(TaskManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.User
                .Include(u => u.ProfileUser)
                .ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.User
                .Where(u => u.Id == id)
                .Include(u => u.ProfileUser)
                .SingleOrDefaultAsync();
        }
    }
}
