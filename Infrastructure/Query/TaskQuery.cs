using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class TaskQuery : ITaskQuery
    {
        private readonly MarketingCRMContext _context;
        public TaskQuery(MarketingCRMContext context)
        {
            _context = context;
        }

        public async Task<Tasks> GetTaskById(Guid id)
        {
            return await _context.Tasks
                .Include(t => t.TaskStatus)
                .Include(t => t.Project)
                .Include(t => t.User)
                .FirstOrDefaultAsync(i => i.TaskID == id);
        }
    }
}
