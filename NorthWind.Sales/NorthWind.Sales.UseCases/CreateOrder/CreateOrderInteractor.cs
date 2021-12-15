using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.UseCasesPorts.CreateOrder;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly ICreateOrderOutputPort OutputPort;
        readonly CreateOrderService Service;

        public CreateOrderInteractor(ICreateOrderOutputPort outputPort, CreateOrderService service)
        {
            OutputPort = outputPort;
            Service = service;
        }

        public ValueTask Handle(CreateOrderDTO order)
        {
            Service.RunValidationGuard(order);
            var OrderAggregate = Service.RunCreateOrderGuard(order);
            Service.RaiseEventIfIsSpecialOrder(OrderAggregate);
            return OutputPort.Handle(OrderAggregate.Id);
        }
    }
}
