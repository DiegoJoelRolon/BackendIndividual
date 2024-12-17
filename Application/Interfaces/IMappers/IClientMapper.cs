using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface IClientMapper
    {
        Task<ClientResponse> CreateClientResponse(Clients client);
        Task<List<ClientResponse>> GetAllClientsResponse(List<Clients> clients);
    }
}
