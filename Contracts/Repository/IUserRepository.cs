using TaskManagement.Model;

namespace TaskManagement.Contracts.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAll();
        Task<User> GetUser(int id);
    }
}
