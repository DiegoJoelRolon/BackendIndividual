using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class ProjectQuery : IProjectQuery
    {
        private readonly MarketingCRMContext _context;
        public ProjectQuery(MarketingCRMContext context)
        {
            _context = context;
        }

        public async Task<List<Projects>> GetAllProjects()
        {
            return await _context.Projects
                .Include(p => p.Clients)
                .Include(p => p.CampaignTypes).ToListAsync();
        }

        public async Task<List<Projects>> GetAllProjects(string? name, int? campaignId, int? clientId, int? offset, int? size)
        {
            var list = _context.Projects
                .Include(p => p.Clients)
                .Include(p => p.CampaignTypes)
                .AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(p => p.ProjectName.Contains(name));
            }
            if (campaignId != null)
            {
                list = list.Where(p => p.CampaignType == campaignId);
            }
            if (clientId != null)
            {
                list = list.Where(p => p.ClientID == clientId);
            }
            if (offset.HasValue)
            {
                list = list.Skip(offset.Value);
            }
            if (size.HasValue)
            {
                list = list.Take(size.Value);
            }

            return await list.ToListAsync();
        }

        public async Task<Projects> GetProjectById(Guid id)
        {
            return await _context.Projects
                .Include(p => p.Clients)
                .Include(p => p.CampaignTypes)
                .Include(p => p.CampaignTypes)
                .Include(p => p.Tasks)
                    .ThenInclude(t => t.User)
                .Include(p => p.Tasks)
                    .ThenInclude(t => t.TaskStatus)
                .Include(p => p.Interactions)
                    .ThenInclude(i => i.InteractionTypes)
                .FirstOrDefaultAsync(p => p.ProjectID == id);

        }
    }
}
