using System;

namespace WebApi.Models.Orders
{
    public class OrderItemModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public OrderItemModel(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}