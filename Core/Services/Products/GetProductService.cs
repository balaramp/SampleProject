using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(Guid productId)
        {
            return _productRepository.Get(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetProductsByStockQuantity(int stockQuantity)
        {
            return _productRepository.GetByQuantity(stockQuantity);
        }
    }
}
