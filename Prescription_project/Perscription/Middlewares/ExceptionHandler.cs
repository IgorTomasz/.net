namespace Perscription.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly string Path = "./logs.txt";

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext) {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                string message = e.Message;
                File.WriteAllText(Path, message);
            }

            
        }
    }
}
