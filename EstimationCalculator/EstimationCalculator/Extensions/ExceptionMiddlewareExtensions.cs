using EstimationCalculator.Middleware;
using Microsoft.AspNetCore.Builder;

namespace EstimationCalculator.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
