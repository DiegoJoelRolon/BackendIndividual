using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITaskQuery
    {
        Task<Tasks> GetTaskById(Guid id);
    }
}
