using TaskManagement.Model;

namespace TaskManagement.Contracts.Repository
{
    public interface IProfileUserRepository : IGenericRepository<ProfileUser>
    {
        Task<ProfileUser> GetByUserId(int userid);
    }
}
