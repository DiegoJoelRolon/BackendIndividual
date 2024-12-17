using Application.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITaskService
    {
        Task<Tasks> AddTaskToProject(Tasks request);
        Task<Tasks> GetTaskById(Guid id);
        Task<Tasks> UpdateTask(TaskRequest request, Guid id);
        Task<Domain.Entities.TaskStatus> GetTaskStatusById(int id);
    }
}
