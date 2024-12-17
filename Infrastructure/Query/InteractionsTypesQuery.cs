using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class InteractionsTypesQuery : IInteractionTypeQuery
    {
        private readonly MarketingCRMContext _context;
        public InteractionsTypesQuery(MarketingCRMContext context)
        {
            _context = context;
        }

        public async Task<List<InteractionTypes>> GetAllInteractionsTypes()
        {
            return await _context.InteractionTypes.ToListAsync();
        }

        public async Task<InteractionTypes> GetInteractionTypeById(int id)
        {
            return await _context.InteractionTypes.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
