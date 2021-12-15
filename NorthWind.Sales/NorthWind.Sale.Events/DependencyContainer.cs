using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
