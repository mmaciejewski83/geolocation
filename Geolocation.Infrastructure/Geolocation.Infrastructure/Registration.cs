using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Geolocation.Core.Repository;

namespace Geolocation.Infrastructure
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IGeoLocationRepository, InMemoryGeoLocationRepository>();
            return services;
        }

        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void UseLoggingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<LoggingRequestMiddleware>();
        }
    }
}
