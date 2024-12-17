using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionCommand _command;
        private readonly IInteractionQuery _query;

        public InteractionService(IInteractionCommand command, IInteractionQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Interactions> AddInteraction(Interactions interaction, Guid id)
        {
            var interactionAdded = await _command.AddInteraction(interaction, id);
            return interactionAdded;
        }
        public async Task<Interactions> GetInteractionById(Guid id)
        {
            return await _query.GetInteractionById(id);
        }

    }
}
