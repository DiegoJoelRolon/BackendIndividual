using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionCommand
    {
        Task<Interactions> AddInteraction(Interactions interaction, Guid id);
    }
}
