using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Interfaces.Validations;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectQuery _query;
        private readonly IProjectCommand _command;
        private readonly IProjectMapper _mapper;
        private readonly IInteractionService _interactionService;
        private readonly IInteractionMapper _interactionMapper;
        private readonly ITaskService _taskService;
        private readonly ITaskMapper _taskMapper;
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly IInteractionTypeService _interactionTypeService;
        private readonly IProjectValidations _projectValidations;
        public ProjectService(IProjectQuery query, IProjectCommand command, IProjectMapper mapper, IInteractionService interactionService, IInteractionMapper interactionMapper, ITaskService taskService, ITaskMapper taskMapper, IUserService userService, IClientService clientService, IInteractionTypeService interactionTypeService, IProjectValidations projectValidations)
        {
            _query = query;
            _mapper = mapper;
            _command = command;
            _interactionService = interactionService;
            _interactionMapper = interactionMapper;
            _taskService = taskService;
            _taskMapper = taskMapper;
            _userService = userService;
            _clientService = clientService;
            _interactionTypeService = interactionTypeService;
            _projectValidations = projectValidations;
        }

        public async Task<TaskResponse> UpdateTask(TaskRequest request, Guid id)
        {
            await _projectValidations.CheckUpdateTaskRequest(request, id);
            var taskUpdated = await _taskService.UpdateTask(request, id);
            return await _taskMapper.GetTaskResponse(await _taskService.GetTaskById(taskUpdated.TaskID));
        }

        public async Task<TaskResponse> AddTaskToProject(TaskRequest request, Guid id)
        {
            await _projectValidations.CheckTaskRequest(request, id);
            var task = new Tasks
            {
                AssignedTo = request.User,
                DueDate = request.DueDate,
                Name = request.Name,
                Status = request.Status,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                ProjectID = id
            };
            var taskAdded = await _taskService.AddTaskToProject(task);
            await UpdateProjectUpdatedate(id);
            return await _taskMapper.GetTaskResponse(await _taskService.GetTaskById(taskAdded.TaskID));
        }

        public async Task<InteractionResponse> AddInteraction(InteractionRequest request, Guid id)
        {
            await _projectValidations.CheckInteractionRequest(request, id);
            var interaction = new Interactions
            {
                Date = request.Date,
                InteractionType = request.InteractionType,
                Notes = request.Notes,
                ProjectID = id
            };
            var interactionAdded = await _interactionService.AddInteraction(interaction, id);
            await UpdateProjectUpdatedate(id);
            return await _interactionMapper.GetInteractionResponse(await _interactionService.GetInteractionById(interactionAdded.InteractionID));

        }

        public async Task<ProjectDetailsResponse> CreateProject(ProjectRequest request)
        {
            await _projectValidations.CheckProjectRequest(request);
            var project = new Projects
            {
                ProjectName = request.Name,
                ClientID = request.Client,
                CampaignType = request.CampaignType,
                StartDate = request.Start,
                EndDate = request.End,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            var result = await _command.CreateProject(project);
            return await _mapper.GetProjectByIdResponse(await _query.GetProjectById(result.ProjectID));
        }

        public async Task<List<ProjectResponse>> GetAllProjectResponse(string? name, int? campaignId, int? clientId, int? offset, int? size)
        {
            var list = await _query.GetAllProjects(name, campaignId, clientId,offset,size);
            return await _mapper.GetAllProjectsResponse(list);
        }

        public async Task<ProjectDetailsResponse> GetProjectById(Guid id)
        {
            await _projectValidations.CheckProjectId(id);
            var project = await _query.GetProjectById(id);
            return await _mapper.GetProjectByIdResponse(await _query.GetProjectById(project.ProjectID));
        }
        public async Task UpdateProjectUpdatedate(Guid id)
        {
            await _command.UpdateProjectUpdatedate(id);
        }
       


    }
}
