using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : IOrderRepository
    {
        private static readonly ConcurrentDictionary<Guid, Order> _orders = new ConcurrentDictionary<Guid, Order>();

        public void Delete(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Order cannot be null.");
            }

            _orders.TryRemove(entity.Id, out _);
        }

        public void DeleteAll()
        {
            _orders.Clear();
        }

        public Order Get(Guid id)
        {
            _orders.TryGetValue(id, out var order);
            return order;
        }

        public IEnumerable<Order> GetByUserId(Guid userId)
        {
            return _orders.Values.Where(order => order.UserId == userId);
        }

        public void Save(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Order cannot be null.");
            }

            _orders[entity.Id] = entity;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders.Values.AsEnumerable();
        }
    }
}
