using NorthWind.Entities.Abstractions;
using NorthWind.Entities.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.DTOs.CreateOrder
{
    public class CreateOrderDetailDTOValidator : 
        ValidatorBase<CreateOrderDetailDTO>, IValidator<CreateOrderDetailDTO>
    {
        public CreateOrderDetailDTOValidator(IValidationService<CreateOrderDetailDTO> service) : 
            base(service)
        {
            AddRuleFor(od => od.ProductId, true)
                .AddRequirement(od => od.ProductId > 0,
                "Debe especificar el identificador del producto");

            AddRuleFor(od => od.Quantity, true)
                .AddRequirement(od => od.Quantity > 0,
                "Debe especificar la cantidad del producto");

            AddRuleFor(od => od.UnitPrice, true)
                .AddRequirement(od => od.UnitPrice > 0,
                "Debe especificar el precio del producto");

        }
    }
}
