using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Kosmoeye_API.Api.Middlewares
{
    public class IpAddressMiddleware
    {
        private readonly RequestDelegate _next;

        public IpAddressMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress?.ToString();

            if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                ip = context.Request.Headers["X-Forwarded-For"];
            }

            context.Items["IpAddress"] = ip ?? "unknown";

            await _next(context);
        }
    }
}
