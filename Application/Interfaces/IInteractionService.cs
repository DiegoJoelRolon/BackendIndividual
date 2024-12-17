using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionService
    {
        Task<Interactions> AddInteraction(Interactions request, Guid id);
        Task<Interactions> GetInteractionById(Guid id);
    }
}
