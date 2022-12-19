using System.Net;
using System.Text.Json;
using FakeUserProject.Service.Helpers;

namespace FakeUserProject.Api.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";
                //set status code according to excepiton type
                switch (error)
                {
                    case UserNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        break;
                }
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
    
    // Extension method used to add the global exception middleware to the HTTP request pipeline.
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}