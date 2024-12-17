using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class ClientCommand : IClientCommand
    {
        private readonly MarketingCRMContext _context;
        public ClientCommand(MarketingCRMContext context)
        {

            _context = context;
        }

        public async Task<Clients> CreateClient(Clients client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return client;

        }
    }
}
