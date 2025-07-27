using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Users.Kosmoeye_Api.Application.DTOS.Users;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Users
{
    public class GetAllUsersHandler
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<GetUserResponse>> Handle()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(user => new GetUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Bio = user.Bio,
                PictureUrl = user.PictureUrl,
                CreatedAt = user.CreatedAt
            }).ToList();
        }
    }
}
