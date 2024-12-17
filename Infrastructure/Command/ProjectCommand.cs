using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class ProjectCommand : IProjectCommand
    {
        private readonly MarketingCRMContext _context;
        private readonly IProjectQuery _projectQuery;
        public ProjectCommand(MarketingCRMContext context, IProjectQuery projectQuery)
        {
            _context = context;
            _projectQuery = projectQuery;
        }

        public async Task<Projects> CreateProject(Projects project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;

        }
        public async Task<Projects> UpdateProjectUpdatedate(Guid id)
        {
            var project = await _projectQuery.GetProjectById(id);
            project.UpdateDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return project;
        }

    }
}
