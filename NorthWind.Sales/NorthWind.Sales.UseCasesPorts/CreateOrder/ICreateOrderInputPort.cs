using NorthWind.Entities.Interfaces;
using NorthWind.Sales.DTOs.CreateOrder;

namespace NorthWind.Sales.UseCasesPorts.CreateOrder
{
    public interface ICreateOrderInputPort:IPort<CreateOrderDTO>
    {
    }
}
