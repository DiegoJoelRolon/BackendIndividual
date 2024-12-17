using Application.Response;

namespace Application.Interfaces
{
    public interface ITaskStatusService
    {
        Task<List<GenericResponse>> GetAllTaskStatus();
    }
}
