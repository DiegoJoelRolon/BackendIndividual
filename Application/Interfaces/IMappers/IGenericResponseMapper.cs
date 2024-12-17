using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface IGenericResponseMapper
    {
        Task<List<GenericResponse>> GetallTaskStatuses(List<Domain.Entities.TaskStatus> taskStatuses);
        Task<List<GenericResponse>> GetallCampaignTypes(List<CampaignTypes> campaignTypes);
        Task<GenericResponse> GetCampaignType(CampaignTypes campaignType);
        Task<List<GenericResponse>> GetallInteractionTypes(List<InteractionTypes> interactionTypes);
        Task<GenericResponse> GetInteractionTypeResponse(InteractionTypes interactionType);
    }
}
