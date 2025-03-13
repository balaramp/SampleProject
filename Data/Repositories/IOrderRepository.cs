using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetByUserId(Guid userId);
        IEnumerable<Order> GetAll();
        void DeleteAll();
    }
}
