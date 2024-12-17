using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class ClientQuery : IClientQuery
    {
        private readonly MarketingCRMContext _context;
        public ClientQuery(MarketingCRMContext context)
        {
            _context = context;
        }

        public async Task<List<Clients>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Clients> GetClientById(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.ClientID == id);
        }
    }
}
