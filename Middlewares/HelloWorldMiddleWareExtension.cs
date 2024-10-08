namespace SampleApplication.Middlewares
{
    public static class HelloWorldMiddleWareExtension
    {
        public static IApplicationBuilder UseHelloWorld(this IApplicationBuilder app) 
        {
            //Ver();
            app.Properties.TryAdd("UseHelloWorld", (Object)UseHelloWorld);
            return app.UseMiddleware<HelloWorldMiddleware>();
        }
    }
}
