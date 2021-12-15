using NorthWind.Sales.Entities.POCOEntities;
using NorthWind.Sales.Entities.ValueObjects;

namespace NorthWind.Sales.Entities.Aggregates
{
    public class OrderAggregate : Order
    {
        readonly List<OrderDetail> OrderDetailsField = new List<OrderDetail>();
        public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;

        public void AddDetail(OrderDetail orderDetail)
        {
            var ExistingOrderDetail = OrderDetailsField.FirstOrDefault(o => o.ProductId == orderDetail.ProductId);
            if (ExistingOrderDetail != null)
            {
                OrderDetailsField.Add(
                ExistingOrderDetail with
                {
                    Quantity = (short)(ExistingOrderDetail.Quantity +
                    orderDetail.Quantity)
                });
                OrderDetailsField.Remove(ExistingOrderDetail);

            }
            else
                OrderDetailsField.Add(orderDetail);
        }

        public void AddDetail(int prodcutId, decimal unitPrice, short quantity) =>
            AddDetail(new OrderDetail(prodcutId, unitPrice, quantity));
    }
}
