using NorthWind.Entities.Interfaces.Events;

namespace NorthWind.Sale.Events
{
    public class SpecialOrderCreatedEvent : IDomainEvent
    {
        public int OrderId { get; }
        public int ProductsCount { get; }

        public SpecialOrderCreatedEvent(int orderId, int productsCount)
        {
            OrderId = orderId;
            ProductsCount = productsCount;
        }
    }
}
