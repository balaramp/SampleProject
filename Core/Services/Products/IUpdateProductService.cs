using System;
using BusinessEntities;

namespace Core.Services.Products
{
    public interface IUpdateProductService
    {
        void Update(Product product, string name, string description, decimal price, int stockQuantity);
    }
}
