using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientResponse>> GetAllClients();
        Task<ClientResponse> CreateClient(ClientRequest request);
        Task<Clients> GetClientById(int id);
    }
}
