using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllUsers();
        Task<Users> GetUserById(int id);
    }
}
