using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Geolocation.Core.Repository;
using Geolocation.Infrastructure.EF;

namespace Geolocation.Infrastructure
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddSingleton<IGeoLocationRepository, InMemoryGeoLocationRepository>();

            services.AddScoped<IGeoLocationRepository, SqlGeoLocationRepository>();
            services
                .AddEntityFrameworkSqlite()
                .AddDbContext<GeoLocationDbContext>();
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

        public static void UseInfrastructure(this IApplicationBuilder app)
        {
            var dbContext = new GeoLocationDbContext();
            dbContext.Database.EnsureCreated();
        }
    }
}
