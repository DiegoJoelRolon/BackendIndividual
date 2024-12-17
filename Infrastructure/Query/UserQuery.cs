using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class UserQuery : IUserQuery
    {
        private readonly MarketingCRMContext _context;
        public UserQuery(MarketingCRMContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetallUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserID == id);
        }
    }
}
