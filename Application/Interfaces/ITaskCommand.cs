using Application.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITaskCommand
    {
        Task<Tasks> AddTaskToProject(Tasks task);
        Task<Tasks> UpdateTask(TaskRequest request, Guid id);
    }
}
