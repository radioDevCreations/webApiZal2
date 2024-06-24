namespace WebApi.Middlewares
{
    public class Middleware_HeadersLogger
    {
        private readonly RequestDelegate _nextDelegate;
        private readonly ILogger<Middleware_HeadersLogger> _logger;

        public Middleware_HeadersLogger(RequestDelegate nextDelegate, ILogger<Middleware_HeadersLogger> logger)
        {
            _nextDelegate = nextDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            foreach (var header in httpContext.Request.Headers)
            {
                _logger.LogInformation("Header: {HeaderKey}: {HeaderValue}", header.Key, header.Value);
            }

            await _nextDelegate(httpContext);
        }
    }
}