using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;

namespace Data.Repositories
{
    [AutoRegister]
    public class ProductRepository : IProductRepository
    {
        private static readonly ConcurrentDictionary<Guid, Product> _products = new ConcurrentDictionary<Guid, Product>();

        public void Delete(Product entity)
        {
            if (entity != null)
            {
                _products.TryRemove(entity.Id, out _);
            }
        }

        public void DeleteAll()
        {
            _products.Clear();
        }

        public Product Get(Guid id)
        {
            _products.TryGetValue(id, out var product);
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _products.Values.AsEnumerable();
        }

        public IEnumerable<Product> GetByQuantity(int StockQuantity)
        {
            return _products.Values.Where(product => product.StockQuantity == StockQuantity);
        }

        public void Save(Product entity)
        {
            if (entity != null)
            {
                _products.TryAdd(entity.Id, entity);
            }
        }
    }
}
