namespace TaskManagement.Contracts.Repository
{
    public interface ITaskRepository : IGenericRepository<Model.Task>
    {
        Task<List<Model.Task>> GetAllTasks();
        Task<Model.Task> GetTaskById(int id);
    }
}
