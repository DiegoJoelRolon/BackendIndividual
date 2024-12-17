using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class UserMapper : IUserMapper
    {
        public Task<List<UserResponse>> GetAllUsersResponse(List<Users> users)
        {
            List<UserResponse> list = new List<UserResponse>();
            foreach (var user in users)
            {
                var response = new UserResponse
                {
                    Email = user.Email,
                    ID = user.UserID,
                    Name = user.Name
                };
                list.Add(response);
            }
            return Task.FromResult(list);
        }
        public Task<UserResponse> GetUserResponse(Users user)
        {
            var response = new UserResponse
            {
                Email = user.Email,
                ID = user.UserID,
                Name = user.Name
            };

            return Task.FromResult(response);
        }
    }
}
