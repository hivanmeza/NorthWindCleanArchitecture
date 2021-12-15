using NorthWind.Entities.Interfaces;
using NorthWind.Sales.Entities.Aggregates;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    public interface ICreateOrderRepository : IUnitOfWork
    {
        void CreateOrder(OrderAggregate orderAggregate);
        void CancelChanges();
    }
}
