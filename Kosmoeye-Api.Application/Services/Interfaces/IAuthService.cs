using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Auth;
using Kosmoeye_Api.Application.DTOS.Users.Create;

namespace Kosmoeye_Api.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginUserResponse> LoginAsync(LoginUserCommand command, string ipAddress);
        Task<CreateUserResponse> SignupAsync(CreateUserComand command);
        Task<LoginUserResponse> RefreshTokenAsync(string token, string ipAddress);
        Task RevokeRefreshTokenAsync(string token, string ipAddress);
    }
}
