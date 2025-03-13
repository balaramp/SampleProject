using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using BusinessEntities;
using Common;
using Core.Services.Products;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(Order order, Guid userId, IEnumerable<OrderItem> items, int totalAmount, string status)
        {
            order.UserId = userId;

            order.SetItems(items);
            order.Status = status;
            order.TotalAmount = totalAmount;
        }
    }
}
