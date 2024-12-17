using Application.Response;

namespace Application.Interfaces
{
    public interface ICampaignTypeService
    {
        Task<List<GenericResponse>> GetAllCampaignTypes();
    }
}
