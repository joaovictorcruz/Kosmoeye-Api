using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Users.Update;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Users
{
    public class ChangePasswordHandler
    {
        private readonly IUserRepository _userRepository;

        public ChangePasswordHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(ChangePasswordCommand command)
        {
            var user = await _userRepository.GetByIdAsync(command.Id);

            if (user == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            var passwordValid = BCrypt.Net.BCrypt.Verify(command.CurrentPassword, user.PasswordHash);
            if (!passwordValid)
                throw new UnauthorizedAccessException("Credenciais inválidas.");

            var newHash = BCrypt.Net.BCrypt.HashPassword(command.NewPassword);
            user.ChangePassword(newHash);

            await _userRepository.UpdateAsync(user);
        }
    }

}
