using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class TasksMapper : ITaskMapper
    {
        private readonly IGenericResponseMapper _genericResponseMapper;
        private readonly IUserMapper _userMapper;

        public TasksMapper(IGenericResponseMapper genericResponseMapper, IUserMapper userMapper)
        {
            _genericResponseMapper = genericResponseMapper;
            _userMapper = userMapper;
        }
        public async Task<TaskResponse> GetTaskResponse(Tasks task)
        {
            var response = new TaskResponse
            {
                ID = task.TaskID,
                DueDate = task.DueDate,
                Name = task.Name,
                ProjectID = task.ProjectID,
                UserAssigned = await _userMapper.GetUserResponse(task.User),
                Status = await TaskStatusResponse(task.TaskStatus),
            };
            return response;
        }

        public async Task<List<TaskResponse>> GetAllTaskResponse(List<Tasks> tasks)
        {

            List<TaskResponse> list = new List<TaskResponse>();
            if (tasks == null)
            {
                return list;
            }
            foreach (var task in tasks)
            {
                var response = new TaskResponse
                {
                    ID = task.TaskID,
                    DueDate = task.DueDate,
                    Name = task.Name,
                    ProjectID = task.ProjectID,
                    UserAssigned = await _userMapper.GetUserResponse(task.User),
                    Status = await TaskStatusResponse(task.TaskStatus),


                };
                
                list.Add(response);
            }
            List<TaskResponse> SortedList = list.OrderBy(o => o.DueDate).ToList();
            return SortedList;
        }

        public Task<GenericResponse> TaskStatusResponse(Domain.Entities.TaskStatus taskStatus)
        {
            var response = new GenericResponse
            {
                Id = taskStatus.Id,
                Name = taskStatus.Name,
            };
            return Task.FromResult(response);
        }


    }
}
