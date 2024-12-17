using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class ProjectMapper : IProjectMapper
    {
        private readonly IClientMapper _clientMapper;
        private readonly IInteractionMapper _interactionMapper;
        private readonly IGenericResponseMapper _genericResponseMapper;
        private readonly ITaskMapper _taskMapper;
        public ProjectMapper(IClientMapper clientMapper, IInteractionMapper interactionMapper, IGenericResponseMapper genericResponseMapper, ITaskMapper taskMapper)
        {
            _clientMapper = clientMapper;
            _genericResponseMapper = genericResponseMapper;
            _interactionMapper = interactionMapper;
            _taskMapper = taskMapper;
        }

        public async Task<List<ProjectResponse>> GetAllProjectsResponse(List<Projects> projects)
        {
            List<ProjectResponse> list = new List<ProjectResponse>();
            foreach (var project in projects)
            {
                var response = new ProjectResponse
                {
                    End = project.EndDate,
                    ID = project.ProjectID,
                    Name = project.ProjectName,
                    Start = project.StartDate,
                    CampaignType = await _genericResponseMapper.GetCampaignType(project.CampaignTypes),
                    Client = await _clientMapper.CreateClientResponse(project.Clients)
                };
                list.Add(response);
            }
            return list;
        }

        public async Task<ProjectDetailsResponse> GetProjectByIdResponse(Projects project)
        {
            var response = new ProjectDetailsResponse
            {
                Data = await GetProjectResponse(project),
                Interactions = await _interactionMapper.GetAllInteractionResponse(project.Interactions),
                Tasks = await _taskMapper.GetAllTaskResponse(project.Tasks)
            };
            return response;
        }

        public async Task<ProjectResponse> GetProjectResponse(Projects project)
        {
            var response = new ProjectResponse
            {
                ID = project.ProjectID,
                Name = project.ProjectName,
                Start = project.StartDate,
                End = project.EndDate,
                Client = await _clientMapper.CreateClientResponse(project.Clients),
                CampaignType = await _genericResponseMapper.GetCampaignType(project.CampaignTypes)
            };
            return response;
        }
    }
}
