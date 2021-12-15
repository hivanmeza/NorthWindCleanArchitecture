using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.Interfaces.Events;
using NorthWind.Entities.Interfaces.Validation;
using NorthWind.Sale.Events;
using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.Entities.Aggregates;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    public class CreateOrderService
    {
        readonly IValidator<CreateOrderDTO> Validator;
        readonly ICreateOrderRepository OrderRepository;
        readonly IDomainEventHub<SpecialOrderCreatedEvent> DomainEventHub;
        readonly ILogWritableRepository LogRepository;

        public CreateOrderService(IValidator<CreateOrderDTO> validator,
            ICreateOrderRepository orderRepository,
            IDomainEventHub<SpecialOrderCreatedEvent> domainEventHub,
            ILogWritableRepository logWritableRepository)
        {
            Validator = validator;
            OrderRepository = orderRepository;
            DomainEventHub = domainEventHub;
            LogRepository = logWritableRepository;
        }

        public void RunValidationGuard(CreateOrderDTO order)
        {
            if (!Validator.Validate(order))
            {
                throw new ValidationException(Validator.Failures);
            }
        }

        public OrderAggregate RunCreateOrderGuard(CreateOrderDTO order)
        {
            OrderAggregate OrderAggregate = new OrderAggregate
            {
                CustomerId = order.CustomerId,
                ShipAddres = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipPostalCode = order.ShipPostalCode
            };
            foreach (var Item in order.OrderDetails)
            {
                OrderAggregate.AddDetail(Item.ProductId, Item.UnitPrice, Item.Quantity);
            }

            try
            {
                LogRepository.Add("Inicio de creacion de orden de compra");
                LogRepository.SaveChanges();

                //iniciar transaccion
                OrderRepository.CreateOrder(OrderAggregate);//devuelve excepcion si hay error

                //Aqui podriamos tener una logica que nos haga cancelar la creacion de la orden
                //OrderRepository.CancelChanges()

                LogRepository.Add($"Order {OrderAggregate.Id} creada.");
                LogRepository.SaveChanges();

                //completa la transaccion
                OrderRepository.SaveChanges();
            }
            catch
            {
                LogRepository.Add("Creacion de orden cancelada");
                LogRepository.SaveChanges();
                throw;
            }
            return OrderAggregate;

        }

        public void RaiseEventIfIsSpecialOrder(OrderAggregate order)
        {
            if (new SpecialOrderSpecification().IsSatisfiedBy(order))
            {
                DomainEventHub.Raise(new SpecialOrderCreatedEvent(order.Id, order.OrderDetails.Count));
            }
        }
    }
}
