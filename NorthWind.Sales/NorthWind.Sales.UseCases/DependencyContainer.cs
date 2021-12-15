using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.UseCases.CreateOrder;
using NorthWind.Sales.UseCasesPorts.CreateOrder;

namespace NorthWind.Sales.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            services.AddScoped<CreateOrderService>();
            services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
            return services;
        }
    }
}
