using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientCommand
    {
        Task<Clients> CreateClient(Clients client);
    }
}
