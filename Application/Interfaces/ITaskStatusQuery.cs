namespace Application.Interfaces
{
    public interface ITaskStatusQuery
    {
        public Task<List<Domain.Entities.TaskStatus>> GetAllStatus();
        Task<Domain.Entities.TaskStatus> GetTaskStatusById(int id);
    }
}
