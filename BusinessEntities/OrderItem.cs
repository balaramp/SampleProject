using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BusinessEntities
{
    public class OrderItem : IdObject
    {
        public Guid ProductId { get;  set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }

        public OrderItem(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be greater than zero.");
        }
    }

}
