using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface IInteractionMapper
    {
        Task<List<InteractionResponse>> GetAllInteractionResponse(List<Interactions> interaction);
        Task<InteractionResponse> GetInteractionResponse(Interactions interaction);
    }
}
