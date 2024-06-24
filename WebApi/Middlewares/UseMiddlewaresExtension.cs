namespace WebApi.Middlewares
{
    public static class UseMiddlewaresExtension
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app) 
        {
            app.UseMiddleware<Middleware_ErrorHandler>();
            app.UseMiddleware<Middleware_HeadersLogger>();

            return app;
        }
    }
}
