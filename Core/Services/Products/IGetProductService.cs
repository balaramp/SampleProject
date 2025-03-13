using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Products
{
    public interface IGetProductService
    {
        Product GetProduct(Guid productId);

        IEnumerable<Product> GetProducts();

        IEnumerable<Product> GetProductsByStockQuantity(int stockQuantity);
    }
}
