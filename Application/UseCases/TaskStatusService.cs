using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Response;

namespace Application.UseCases
{
    public class TaskStatusService : ITaskStatusService
    {
        private readonly ITaskStatusQuery _query;
        private readonly IGenericResponseMapper _genericResponseMapper;

        public TaskStatusService(ITaskStatusQuery query, IGenericResponseMapper genericResponseMapper)
        {
            _genericResponseMapper = genericResponseMapper;
            _query = query;
        }

        public async Task<List<GenericResponse>> GetAllTaskStatus()
        {
            var list = await _query.GetAllStatus();
            return await _genericResponseMapper.GetallTaskStatuses(list);
        }
    }
}
