using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class InteracionCommand : IInteractionCommand
    {
        private readonly MarketingCRMContext _context;
        public InteracionCommand(MarketingCRMContext context)
        {
            _context = context;
        }

        public async Task<Interactions> AddInteraction(Interactions interaction, Guid id)
        {
            _context.Interactions.Add(interaction);
            await _context.SaveChangesAsync();
            return interaction;
        }
    }
}
