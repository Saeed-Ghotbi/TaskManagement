using Microsoft.EntityFrameworkCore;
using TaskManagement.Context;
using TaskManagement.Contracts.Repository;
using TaskManagement.Model;

namespace TaskManagement.Repository
{
    public class ProfileUserRepository : GenericRepository<ProfileUser>, IProfileUserRepository
    {
        private readonly TaskManagementContext _context;

        public ProfileUserRepository(TaskManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProfileUser> GetByUserId(int userid)
        {
            return await _context.ProfileUser
                .Where(pu => pu.UserId == userid)
                .FirstOrDefaultAsync();
        }
    }
}
