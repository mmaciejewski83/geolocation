using Geolocation.Application.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.Application
{
    public static class Registration
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            Assembly callingAssembly = Assembly.GetExecutingAssembly();
            services.Scan(delegate (ITypeSourceSelector scan)
            {
                scan.FromAssemblies(callingAssembly)
                .AddClasses(delegate (IImplementationTypeFilter classes)
                    {
                        classes.AssignableTo(typeof(IQueryHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .AsSelf()
                    .WithScopedLifetime()
                .AddClasses(delegate (IImplementationTypeFilter classes)
                    {
                        classes.AssignableTo(typeof(ICommandHandler<>));
                    })
                    .AsImplementedInterfaces()
                    .AsSelf()
                    .WithScopedLifetime();
            });
            return services;
        }
    }
}
