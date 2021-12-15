using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Events;

namespace NorthWind.Sale.Events
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddEventHandlers(
            this IServiceCollection services)
        {
            services.AddScoped<IDomainEventHandler<SpecialOrderCreatedEvent>,
                 SpecialCreateEventHandler>();
            return services;
        }
    }
}
