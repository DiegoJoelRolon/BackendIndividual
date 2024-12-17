using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProjectCommand
    {
        Task<Projects> CreateProject(Projects project);
        Task<Projects> UpdateProjectUpdatedate(Guid id);

    }
}
