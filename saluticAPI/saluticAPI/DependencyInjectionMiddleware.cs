using BusinessLogic.RecruiterBL;
using System.Globalization;

namespace saluticAPI
{
    public class DependencyInjectionMiddleware
    {
        private readonly RequestDelegate _next;

        public DependencyInjectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceCollection services)
        {
            services.AddScoped<IRecruiterBL, RecruiterBL>();
        }
    }


    public static class DependencyInjectionMiddlewareExtensions
    {
        public static IApplicationBuilder UseDependencyInjectionMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DependencyInjectionMiddleware>();
        }
    }


}
