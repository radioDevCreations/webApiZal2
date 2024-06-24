
namespace WebApi.Middlewares
{
public class Middleware_ErrorHandler
    {
        private readonly RequestDelegate _nextDelegate;
        private readonly ILogger<Middleware_ErrorHandler> _logger;
        public Middleware_ErrorHandler(RequestDelegate nextDelegate, ILogger<Middleware_ErrorHandler> logger)
        {
            _nextDelegate = nextDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _nextDelegate(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("An error occurred.");
            }
        }
    }
}
