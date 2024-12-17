using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserQuery
    {
        Task<List<Users>> GetallUsers();
        Task<Users> GetUserById(int id);
    }
}
