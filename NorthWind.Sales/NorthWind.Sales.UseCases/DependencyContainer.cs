using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Validation;
using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.UseCases.CreateOrder;
using NorthWind.Sales.UseCasesPorts.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            services.AddScoped<CreateOrderService>();
            services.AddScoped<ICreateOrderInputPort,CreateOrderInteractor>();
            return services;
        }
    }
}
