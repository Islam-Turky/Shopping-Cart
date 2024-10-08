namespace SampleApplication.Middlewares
{
    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate _next;
        public HelloWorldMiddleware(RequestDelegate next) { _next = next; }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.Contains("/store/index")) 
            {
                await context.Response.WriteAsync("Hello World!");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
