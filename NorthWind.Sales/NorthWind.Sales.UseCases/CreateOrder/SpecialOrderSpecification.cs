using NorthWind.Entities.Abstractions;
using NorthWind.Sales.Entities.Aggregates;
using System.Linq.Expressions;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    public class SpecialOrderSpecification : Specification<OrderAggregate>
    {
        public override Expression<Func<OrderAggregate, bool>> ConditionExpression =>
            order => order.OrderDetails.Count > 3;
    }
}
