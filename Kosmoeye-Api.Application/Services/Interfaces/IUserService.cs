﻿using Kosmoeye_Api.Application.DTOS.Users.Create;
using Kosmoeye_Api.Application.DTOS.Users.Kosmoeye_Api.Application.DTOS.Users;
using Kosmoeye_Api.Application.DTOS.Users.Search;
using Kosmoeye_Api.Application.DTOS.Users.Update;

namespace Kosmoeye_API.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<GetUserResponse>> GetAllUsersAsync();
        Task<GetUserResponse> GetUserByIdAsync(Guid id);
        Task UpdateUserAsync(UpdateUserCommand command);
        Task ChangePasswordAsync(ChangePasswordCommand command);
        Task DeleteUserAsync(Guid id);
        Task<List<SearchUserResponse>> SearchUsersAsync(SearchUserQuery query);
    }

}
