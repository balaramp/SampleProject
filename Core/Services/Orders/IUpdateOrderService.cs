using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        void Update(Order order, Guid userId, IEnumerable<OrderItem> items, int totalAmount, string status);
    }
}
