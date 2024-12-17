using Application.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Validations
{
    public interface IProjectValidations
    {
        Task<bool> CheckProjectId(Guid id);
        Task<bool> CheckProjectRequest(ProjectRequest request);
        Task<bool> CheckInteractionRequest(InteractionRequest request, Guid id);
        Task<bool> CheckTaskRequest(TaskRequest request, Guid id);
        Task<bool> CheckUpdateTaskRequest(TaskRequest request, Guid id);
    }
}
