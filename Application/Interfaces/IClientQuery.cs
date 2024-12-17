using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientQuery
    {
        Task<List<Clients>> GetClients();
        Task<Clients> GetClientById(int id);
    }
}
