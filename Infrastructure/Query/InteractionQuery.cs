using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class InteractionQuery : IInteractionQuery
    {
        private readonly MarketingCRMContext _context;
        public InteractionQuery(MarketingCRMContext context)
        {
            _context = context;
        }

        public async Task<Interactions> GetInteractionById(Guid id)
        {
            return await _context.Interactions
                .Include(i => i.InteractionTypes)
                .FirstOrDefaultAsync(i => i.InteractionID == id);
        }
    }
}
