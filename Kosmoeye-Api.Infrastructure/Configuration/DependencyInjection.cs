using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.Services;
using Kosmoeye_Api.Application.UseCases.Artworks;
using Kosmoeye_Api.Application.UseCases.Auth;
using Kosmoeye_Api.Application.UseCases.Users;
using Kosmoeye_Api.Domain.Interfaces.Repositories;
using Kosmoeye_Api.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;



namespace Kosmoeye_Api.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IArtworkRepository, ArtworkRepository>();

            // Handlers
            //Auth
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<LoginUserHandler>();
            services.AddScoped<RefreshTokenHandler>();
            services.AddScoped<RevokeRefreshTokenHandler>();
            services.AddScoped<TokenGenerator>();

            //User
            services.AddScoped<GetAllUsersHandler>();
            services.AddScoped<GetUserByIdHandler>();
            services.AddScoped<UpdateUserHandler>();
            services.AddScoped<ChangePasswordHandler>();
            services.AddScoped<DeleteUserHandler>();
            
            //Artwork
            services.AddScoped<CreateArtworkHandler>();

            return services;
        }
    }
}
