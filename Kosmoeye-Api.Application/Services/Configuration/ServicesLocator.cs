using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_API.Api.Services;
using Microsoft.Extensions.DependencyInjection; 
using Kosmoeye_API.Api.Services.Interfaces;

namespace Kosmoeye_Api.Application.Services.Configuration
{
    public static class ServicesLocator
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
