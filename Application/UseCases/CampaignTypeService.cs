using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Response;

namespace Application.UseCases
{
    public class CampaignTypeService : ICampaignTypeService
    {
        private readonly ICampaignTypeQuery _query;
        private readonly IGenericResponseMapper _mapper;
        public CampaignTypeService(ICampaignTypeQuery query, IGenericResponseMapper mapper)
        {
            _mapper = mapper;
            _query = query;
        }

        public async Task<List<GenericResponse>> GetAllCampaignTypes()
        {
            var list = await _query.GetallCampaignTypes();
            return await _mapper.GetallCampaignTypes(list);
        }
    }
}
