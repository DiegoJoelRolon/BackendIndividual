using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class InteractionTypeService : IInteractionTypeService
    {
        private readonly IInteractionTypeQuery _query;
        private readonly IGenericResponseMapper _mapper;
        public InteractionTypeService(IInteractionTypeQuery query, IGenericResponseMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<List<GenericResponse>> GetAllInteractionTypes()
        {
            var list = await _query.GetAllInteractionsTypes();
            return await _mapper.GetallInteractionTypes(list);
        }
        public async Task<InteractionTypes> GetInteractionTypesById(int id)
        {
            return await _query.GetInteractionTypeById(id);
        }
    }
}
