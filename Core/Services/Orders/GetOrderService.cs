using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetOrder(Guid orderId)
        {
            return _orderRepository.Get(orderId);
        }

        public IEnumerable<Order> GetOrdersByUser(Guid userId)
        {
            return _orderRepository.GetByUserId(userId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetAll();
        }
    }
}
