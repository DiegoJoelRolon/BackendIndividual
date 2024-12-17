using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionTypeService
    {
        Task<List<GenericResponse>> GetAllInteractionTypes();
        Task<InteractionTypes> GetInteractionTypesById(int id);
    }
}
