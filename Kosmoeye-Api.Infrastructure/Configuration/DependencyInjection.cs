using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<LoginUserHandler>();
            services.AddScoped<GetAllUsersHandler>();
            services.AddScoped<GetUserByIdHandler>();

            return services;
        }
    }
}
