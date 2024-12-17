using Application.Exceptions;
using Application.Interfaces.IMappers;
using Application.Interfaces;
using Application.Interfaces.Validations;
using Application.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class ProjectValidations : IProjectValidations
    {
        private readonly IProjectQuery _query;
        private readonly ITaskQuery _taskQuery;
        private readonly ITaskService _taskService;
        
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly IInteractionTypeService _interactionTypeService;

        public ProjectValidations(ITaskQuery taskQuery, IProjectQuery query,ITaskService taskService, ITaskMapper taskMapper, IUserService userService, IClientService clientService, IInteractionTypeService interactionTypeService) 
        {
            _query = query;
            _taskQuery = taskQuery;
            _taskService = taskService;
            _userService = userService;
            _clientService = clientService;
            _interactionTypeService = interactionTypeService;
        }
        public async Task<bool> CheckInteractionRequest(InteractionRequest request, Guid id)
        {
            if (await _query.GetProjectById(id) == null)
            {
                throw new Conflict("There´s no project with that Id");
            }
            if (await _interactionTypeService.GetInteractionTypesById(request.InteractionType) == null)
            {
                throw new Conflict("InteractionType must be a number between 1 and 4");
            }
            return false;
        }

        public async Task<bool> CheckProjectId(Guid id)
        {
            if (await _query.GetProjectById(id) == null)
            {
                throw new ExceptionNotFound("There´s no project with that Id");
            }
            return false;
        }

        public async Task<bool> CheckProjectRequest(ProjectRequest request)
        {
            var projectList = await _query.GetAllProjects();

            foreach (var project in projectList)
            {
                if (project.ProjectName == request.Name)
                {
                    throw new Conflict("There´s already a project with that name");
                }
            }
            if (await _clientService.GetClientById(request.Client) == null)
            {
                throw new Conflict("There´s no client with that id");
            }
            if (request.CampaignType < 1 || request.CampaignType > 4)
            {
                throw new Conflict("There´s no campaignType with that id");
            }
            if (request.End < request.Start)
            {
                throw new Conflict("End cant be before start");
            }

            return false;
        }

        public async Task<bool> CheckTaskRequest(TaskRequest request, Guid id)
        {
            if (await _query.GetProjectById(id) == null)
            {
                throw new Conflict("There´s no project with that Id");
            }
            if (await _userService.GetUserById(request.User) == null)
            {
                throw new Conflict("Cant find user with that id");
            }
            if (await _taskService.GetTaskStatusById(request.Status) == null)
            {
                throw new Conflict("Status must be a number between 1 and 5");
            }

            if (request.DueDate.Date < DateTime.Now.Date)
            {
                throw new Conflict("DueDate must be bigger than current date");
            }

            return false;
        }

        public async Task<bool> CheckUpdateTaskRequest(TaskRequest request, Guid id)
        {
            if (await _taskQuery.GetTaskById(id) == null)
            {
                throw new Conflict("There´s no task with that Id");
            }
            if (await _userService.GetUserById(request.User) == null)
            {
                throw new Conflict("Cant find user with that id");
            }
            if (await _taskService.GetTaskStatusById(request.Status) == null)
            {
                throw new Conflict("Status must be a number between 1 and 5");
            }

            if (request.DueDate.Date < DateTime.Now.Date)
            {
                throw new Conflict("DueDate must be bigger than current date");
            }

            return false;
        }
    }
}
