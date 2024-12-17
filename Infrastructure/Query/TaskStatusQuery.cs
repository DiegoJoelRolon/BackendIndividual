using Application.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class TaskStatusQuery : ITaskStatusQuery
    {
        private readonly MarketingCRMContext _context;
        public TaskStatusQuery(MarketingCRMContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.TaskStatus>> GetAllStatus()
        {
            return await _context.TaskStatuses.ToListAsync();
        }
        public async Task<Domain.Entities.TaskStatus> GetTaskStatusById(int id)
        {
            return await _context.TaskStatuses.FirstOrDefaultAsync(ts => ts.Id == id);
        }
    }
}
