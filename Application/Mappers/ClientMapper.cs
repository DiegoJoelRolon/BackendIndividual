using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class ClientMapper : IClientMapper
    {
        public Task<ClientResponse> CreateClientResponse(Clients client)
        {
            var response = new ClientResponse
            {
                Id = client.ClientID,
                Address = client.Address,
                Company = client.Company,
                Email = client.Email,
                Name = client.Name,
                Phone = client.Phone

            };
            return Task.FromResult(response);
        }

        public Task<List<ClientResponse>> GetAllClientsResponse(List<Clients> clients)
        {
            List<ClientResponse> list = new List<ClientResponse>();
            foreach (var client in clients)
            {
                var response = new ClientResponse
                {
                    Id = client.ClientID,
                    Address = client.Address,
                    Company = client.Company,
                    Email = client.Email,
                    Name = client.Name,
                    Phone = client.Phone
                };
                list.Add(response);
            }
            return Task.FromResult(list);
        }
    }
}
