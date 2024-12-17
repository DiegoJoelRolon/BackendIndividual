using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionQuery
    {
        Task<Interactions> GetInteractionById(Guid id);
    }
}
