using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Users.Update;
using Kosmoeye_Api.Domain.Entities;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Users
{
    public class UpdateUserHandler
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand command)
        {
            var user = await _userRepository.GetByIdAsync(command.Id);

            if (user == null)
                throw new KeyNotFoundException("Usuario não encontrado");

            if (!string.IsNullOrWhiteSpace(command.Username))
            {
                user.UpdateUsername(command.Username);
            }

            user.UpdateProfile(command.Bio, command.PictureUrl);

            await _userRepository.UpdateAsync(user);
        }
    }
}
