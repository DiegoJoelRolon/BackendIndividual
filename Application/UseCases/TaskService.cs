using Application.Interfaces;
using Application.Request;
using Domain.Entities;

namespace Application.UseCases
{
    public class TaskService : ITaskService
    {
        private readonly ITaskCommand _command;
        private readonly ITaskQuery _query;
        private readonly ITaskStatusQuery _statusQuery;
        public TaskService(ITaskCommand command, ITaskQuery query, ITaskStatusQuery statusQuery)
        {
            _command = command;
            _query = query;
            _statusQuery = statusQuery;
        }
        public async Task<Tasks> UpdateTask(TaskRequest request, Guid id)
        {
            await _command.UpdateTask(request, id);
            return await _query.GetTaskById(id);
        }

        public async Task<Tasks> AddTaskToProject(Tasks request)
        {
            var task = await _command.AddTaskToProject(request);
            return await _query.GetTaskById(task.TaskID);
        }

        public async Task<Tasks> GetTaskById(Guid id)
        {
            return await _query.GetTaskById(id);
        }
        public async Task<Domain.Entities.TaskStatus> GetTaskStatusById(int id)
        {
            return await _statusQuery.GetTaskStatusById(id);
        }
    }
}
