using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Validation;
using NorthWind.Sales.DTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.DTOs
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDTOValidator(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateOrderDetailDTO>, CreateOrderDetailDTOValidator>();
            services.AddScoped<IValidator<CreateOrderDTO>,CreateOrderDTOValidator>();
            return services;
        }
    }
}
