using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class GenericResponseMapper : IGenericResponseMapper
    {

        public Task<List<GenericResponse>> GetallCampaignTypes(List<CampaignTypes> campaignTypes)
        {
            List<GenericResponse> list = new();
            foreach (var campaingtype in campaignTypes)
            {
                var response = new GenericResponse
                {
                    Id = campaingtype.Id,
                    Name = campaingtype.Name
                };
                list.Add(response);
            }
            return Task.FromResult(list);
        }

        public Task<GenericResponse> GetCampaignType(CampaignTypes campaignType)
        {
            var response = new GenericResponse
            {
                Id = campaignType.Id,
                Name = campaignType.Name
            };
            return Task.FromResult(response);
        }

        public Task<List<GenericResponse>> GetallInteractionTypes(List<InteractionTypes> interactionTypes)
        {
            List<GenericResponse> list = new List<GenericResponse>();
            foreach (var item in interactionTypes)
            {
                var response = new GenericResponse
                {
                    Id = item.Id,
                    Name = item.Name
                };
                list.Add(response);
            }
            return Task.FromResult(list);
        }

        public Task<GenericResponse> GetInteractionTypeResponse(InteractionTypes interactionType)
        {
            var response = new GenericResponse
            {
                Id = interactionType.Id,
                Name = interactionType.Name
            };
            return Task.FromResult(response);
        }

        public Task<List<GenericResponse>> GetallTaskStatuses(List<Domain.Entities.TaskStatus> taskStatuses)
        {
            List<GenericResponse> list = new List<GenericResponse>();
            foreach (var taskstatus in taskStatuses)
            {
                var response = new GenericResponse
                {
                    Id = taskstatus.Id,
                    Name = taskstatus.Name
                };
                list.Add(response);
            }
            return Task.FromResult(list);
        }


    }
}
