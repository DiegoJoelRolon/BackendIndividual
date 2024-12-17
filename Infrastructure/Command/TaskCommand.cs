using Application.Interfaces;
using Application.Request;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class TaskCommand : ITaskCommand
    {
        private readonly MarketingCRMContext _context;
        private readonly ITaskQuery _taskQuery;
        public TaskCommand(MarketingCRMContext context, ITaskQuery taskQuery)
        {
            _context = context;
            _taskQuery = taskQuery;
        }

        public async Task<Tasks> AddTaskToProject(Tasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;

        }
        public async Task<Tasks> UpdateTask(TaskRequest request, Guid id)
        {
            var taskUpdated = await _taskQuery.GetTaskById(id);
            taskUpdated.Name = request.Name;
            taskUpdated.DueDate = request.DueDate;
            taskUpdated.AssignedTo = request.User;
            taskUpdated.Status = request.Status;
            taskUpdated.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return taskUpdated;
        }
    }
}
