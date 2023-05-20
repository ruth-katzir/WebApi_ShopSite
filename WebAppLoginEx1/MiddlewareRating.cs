using entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Service;
using System.Net;
using System.Threading.Tasks;

namespace WebAppLoginEx1
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareRating
    {
        private readonly RequestDelegate _next;

        // private readonly IRating <MiddlewareRating> _service;
        // ILogger<Middleware> _logger;

        public MiddlewareRating(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingService service)
        {
            Rating rating = new()
            {
                Host = httpContext.Request.Host.Host,
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                Referer = httpContext.Request.Headers.Referer,
                UserAgent = httpContext.Request.Headers.UserAgent,
                RecordDate = DateTime.Now
            };
            await service.addRatingAsync(rating);
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareRatingExtensions
    {
        public static IApplicationBuilder UseMiddlewareRating(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareRating>();
        }
    }
}
