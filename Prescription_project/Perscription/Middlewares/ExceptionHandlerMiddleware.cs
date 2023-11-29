namespace Perscription.Middlewares
{
    public static class ExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseGreatExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandler>();
        }
    }
}
