using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface IUserMapper
    {
        Task<List<UserResponse>> GetAllUsersResponse(List<Users> users);
        Task<UserResponse> GetUserResponse(Users user);
    }
}
