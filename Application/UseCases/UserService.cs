using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class UserService : IUserService
    {
        private readonly IUserQuery _query;
        private readonly IUserMapper _mapper;
        public UserService(IUserQuery query, IUserMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<List<UserResponse>> GetAllUsers()
        {
            var list = await _query.GetallUsers();
            return await _mapper.GetAllUsersResponse(list);
        }

        public async Task<Users> GetUserById(int id)
        {
            var user = await _query.GetUserById(id);
            return user;
        }
    }
}
