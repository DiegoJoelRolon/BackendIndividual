using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class InteractionMapper : IInteractionMapper
    {
        private readonly IGenericResponseMapper _genericResponseMapper;
        public InteractionMapper(IGenericResponseMapper genericResponseMapper)
        {
            _genericResponseMapper = genericResponseMapper;
        }

        public async Task<List<InteractionResponse>> GetAllInteractionResponse(List<Interactions> interactions)
        {
            List<InteractionResponse> list = new List<InteractionResponse>();
            foreach (var interaction in interactions)
            {
                var response = new InteractionResponse
                {
                    Id = interaction.InteractionID,
                    Notes = interaction.Notes,
                    Date = interaction.Date,
                    ProjectID = interaction.ProjectID,
                    InteractionType = await _genericResponseMapper.GetInteractionTypeResponse(interaction.InteractionTypes)
                };
                list.Add(response);
            }
            List<InteractionResponse> sortedList = list.OrderBy(o => o.Date).ToList();
            return list;
        }

        public async Task<InteractionResponse> GetInteractionResponse(Interactions interaction)
        {
            var response = new InteractionResponse
            {
                Id = interaction.InteractionID,
                Notes = interaction.Notes,
                Date = interaction.Date,
                ProjectID = interaction.ProjectID,
                InteractionType = await _genericResponseMapper.GetInteractionTypeResponse(interaction.InteractionTypes)
            };
            return response;
        }
    }
}
