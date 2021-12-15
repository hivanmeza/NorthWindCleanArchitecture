using NorthWind.Entities.Abstractions;
using NorthWind.Entities.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.DTOs.CreateOrder
{
    public class CreateOrderDTOValidator :
        ValidatorBase<CreateOrderDTO>
    {
        public CreateOrderDTOValidator(
            IValidationService<CreateOrderDTO> service,
            IValidationService<CreateOrderDetailDTO> orderDetailValidationservice)
            : base(service)
        {
            // Mejora: Que por default el parámetro StopOnFirstFailure sea true.

            AddRuleFor(o => o.CustomerId,true)
                .AddRequirement(o => !string.IsNullOrWhiteSpace(o.CustomerId),
                "Debe proporcionar el identificador del cliente")
                .AddRequirement(o => o.CustomerId.Length == 5,
                "La longitud del identificador debe ser 5");

            AddRuleFor(o => o.ShipAddress, true)
                .AddRequirement(o => !string.IsNullOrWhiteSpace(o.ShipAddress),
                "Debe proporcionar la dirección de envío")
                .AddRequirement(o => o.ShipAddress.Length <= 60,
                "La longitud máxima de la dirección es 60");

            AddRuleFor(o => o.ShipCity, true)
                .AddRequirement(o => !string.IsNullOrWhiteSpace(o.ShipCity),
                "Debe proporcionar la ciudad de envío")
                .AddRequirement(o => o.ShipCity.Length >= 3,
                "Debe especificar al menos 3 caracteres del nombre de la ciudad.")
                .AddRequirement(o => o.ShipCity.Length <= 15,
                "La longitud máxima de la ciudad es 15");

            AddRuleFor(o => o.ShipCountry, true)
                .AddRequirement(o => !string.IsNullOrWhiteSpace(o.ShipCountry),
                "Debe proporcionar el país de envío")
                .AddRequirement(o => o.ShipCountry.Length >= 3,
                "Debe especificar al menos 3 caracteres del nombre del país.")
                .AddRequirement(o => o.ShipCountry.Length <= 15,
                "La longitud máxima del país es 15");

            AddRuleFor(o => o.ShipPostalCode, true)
                .AddRequirement(o => o.ShipCity.Length <= 10,
                "La longitud máxima del código postal es 10");

            AddRuleFor(o => o.OrderDetails, true)
                .AddRequirement(o => o.OrderDetails != null,
                "Debe especificar los productos de la orden")
                .AddRequirement(o => o.OrderDetails.Any(),
                "Debe especificar al menos un producto de la orden")
                .AddCollectionItemsValidator(o => SetValidatorFor(o.OrderDetails,
                new CreateOrderDetailDTOValidator(orderDetailValidationservice)));
        }
    }
}
