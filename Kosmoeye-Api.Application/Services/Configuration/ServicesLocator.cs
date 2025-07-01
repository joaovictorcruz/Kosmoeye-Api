using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.Services.Interfaces;
using Kosmoeye_API.Api.Services;
using Kosmoeye_API.Api.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection; 

namespace Kosmoeye_Api.Application.Services.Configuration
{
    public static class ServicesLocator
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
