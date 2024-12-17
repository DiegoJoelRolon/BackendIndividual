using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProjectQuery
    {
        Task<Projects> GetProjectById(Guid id);
        Task<List<Projects>> GetAllProjects(string? name, int? campaignId, int? clientId, int? offset, int? size);
        Task<List<Projects>> GetAllProjects();
    }
}
