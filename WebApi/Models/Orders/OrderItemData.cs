using BusinessEntities;
using System;

namespace WebApi.Models.Orders
{
    public class OrderItemData : IdObjectData
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public OrderItemData(OrderItem item) : base(item)
        {
            ProductId = item.ProductId;
            Quantity = item.Quantity;
        }
    }
}