using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        Order Create(Guid OrderId, Guid userId, IEnumerable<OrderItem> items, int totalAmount, string status);
    }
}
