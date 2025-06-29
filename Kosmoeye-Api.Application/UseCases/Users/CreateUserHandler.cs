using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Users;
using Kosmoeye_Api.Domain.Entities;
using Kosmoeye_Api.Domain.Interfaces.Repositories;
using BCrypt.Net;

namespace Kosmoeye_Api.Application.UseCases.Users
{
    public class CreateUserHandler
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserComand command)
        {
            var existingUser = await _userRepository.GetByEmailAsync(command.Email);
            if (existingUser != null)
                throw new InvalidOperationException("Este e-mail já está em uso.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(command.Password);

            var user = new User(command.Username, command.Email, passwordHash);

            await _userRepository.AddAsync(user);

            return new CreateUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };

        }
    }
}
