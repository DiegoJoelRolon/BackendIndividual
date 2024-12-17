using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface IProjectMapper
    {
        Task<ProjectResponse> GetProjectResponse(Projects project);
        Task<ProjectDetailsResponse> GetProjectByIdResponse(Projects project);
        Task<List<ProjectResponse>> GetAllProjectsResponse(List<Projects> projects);
    }
}
