using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Users;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderService(IIdObjectFactory<Order> orderFactory, IOrderRepository orderRepository, IUpdateOrderService updateOrderService)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
        }

        public Order Create(Guid id, Guid userId, IEnumerable<OrderItem> items, int totalAmount, string status)
        {
            var order = _orderFactory.Create(id);

            _updateOrderService.Update(order, userId, items, totalAmount, status);

            _orderRepository.Save(order);

            return order;
        }
    }
}
