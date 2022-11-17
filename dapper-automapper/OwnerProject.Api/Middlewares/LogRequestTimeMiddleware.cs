namespace OwnerProject.Api.Middlewares
{
    public class LogRequestTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogRequestTimeMiddleware> _logger;
        public LogRequestTimeMiddleware(RequestDelegate next, ILogger<LogRequestTimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        //request method, request type, time
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            await _next(httpContext);
            watch.Stop();
            var elapsedTime = watch.ElapsedMilliseconds;
            var requestPath = httpContext.Request.Host + httpContext.Request.Path;
            if (elapsedTime > 500)
            {
                _logger.LogWarning("[Request Path {}], \n[Time Elapsed {}]", requestPath, elapsedTime);
            }
        }
    }
    public static class LogRequesTimeExtension
    {
        public static IApplicationBuilder UseRequestTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogRequestTimeMiddleware>();
        }

    }
}