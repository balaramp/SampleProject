using System;
using BusinessEntities;

namespace WebApi.Models.Products
{
    public class ProductData : IdObjectData
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }

        public ProductData(Product product) : base(product)
        {
            ProductId = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            StockQuantity = product.StockQuantity;
            CreatedAt = product.CreatedAt;
        }
    }
}
