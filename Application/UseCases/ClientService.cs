using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Interfaces.Validations;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class ClientService : IClientService
    {
        private readonly IClientCommand _command;
        private readonly IClientQuery _query;
        private readonly IClientMapper _mapper;
        private readonly IClientValidations _validations;
        public ClientService(IClientCommand command, IClientQuery query, IClientMapper mapper,IClientValidations clientValidations)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _validations = clientValidations;
        }

        public async Task<ClientResponse> CreateClient(ClientRequest request)
        {
            await _validations.CheckCreatingClient(request);
            var client = new Clients
            {
                Address = request.Address,
                Company = request.Company,
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,
                CreateDate = DateTime.Now,
            };
            var cli = await _command.CreateClient(client);
            return await _mapper.CreateClientResponse(await GetClientById(cli.ClientID));
        }

        public async Task<List<ClientResponse>> GetAllClients()
        {
            var list = await _query.GetClients();
            return await _mapper.GetAllClientsResponse(list);

        }
        public async Task<Clients> GetClientById(int id)
        {
            return await _query.GetClientById(id);
        }
    }
}
