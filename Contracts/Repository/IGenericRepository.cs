namespace TaskManagement.Contracts.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<bool> Exist(int id);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
