using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICampaignTypeQuery
    {
        Task<List<CampaignTypes>> GetallCampaignTypes();
    }
}
