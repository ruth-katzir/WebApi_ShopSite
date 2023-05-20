using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace WebAppLoginEx1
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareLogging
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewareLogging> _logger;

        public MiddlewareLogging(RequestDelegate next, ILogger<MiddlewareLogging> logger)
        {
            _next = next;
            _logger=logger;
        }

        public async Task  Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception e)
            {
                _logger.LogError($"Error from middelware {1} at {2}", e.Message , e.StackTrace);
                httpContext.Response.StatusCode = 500;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareLoggingExtensions
    {
        public static IApplicationBuilder UseMiddlewareLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareLogging>();
        }
    }
}
