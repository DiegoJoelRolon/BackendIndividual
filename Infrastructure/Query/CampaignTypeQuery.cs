using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class CampaignTypeQuery : ICampaignTypeQuery
    {
        private readonly MarketingCRMContext _context;
        public CampaignTypeQuery(MarketingCRMContext context)
        {
            _context = context;
        }

        public async Task<List<CampaignTypes>> GetallCampaignTypes()
        {
            return await _context.CampaignTypes.ToListAsync();
        }
    }
}
