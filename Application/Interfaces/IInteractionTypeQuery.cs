using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionTypeQuery
    {
        Task<List<InteractionTypes>> GetAllInteractionsTypes();
        Task<InteractionTypes> GetInteractionTypeById(int id);
    }
}
