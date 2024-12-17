using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectResponse>> GetAllProjectResponse(string? name, int? campaignId, int? clientId, int? offset, int? size);
        Task<ProjectDetailsResponse> GetProjectById(Guid id);
        Task<ProjectDetailsResponse> CreateProject(ProjectRequest request);
        Task<InteractionResponse> AddInteraction(InteractionRequest request, Guid id);
        Task<TaskResponse> AddTaskToProject(TaskRequest request, Guid id);
        Task<TaskResponse> UpdateTask(TaskRequest request, Guid id);
        Task UpdateProjectUpdatedate(Guid id);
    }
}
