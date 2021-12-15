using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Events;
using NorthWind.Entities.Services;

namespace NorthWind.Entities
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEntitiesServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDomainEventHub<>), typeof(DomainEventHub<>));
            return services;
        }
    }
}
