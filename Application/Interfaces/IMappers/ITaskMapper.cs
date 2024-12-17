using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface ITaskMapper
    {
        Task<List<TaskResponse>> GetAllTaskResponse(List<Tasks> tasks);
        Task<TaskResponse> GetTaskResponse(Tasks task);
    }
}
