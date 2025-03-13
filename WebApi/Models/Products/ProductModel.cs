using System;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public ProductModel(string name, string description, decimal price, int stockQuantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.", nameof(name));

            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.", nameof(price));

            if (stockQuantity < 0)
                throw new ArgumentException("Stock quantity cannot be negative.", nameof(stockQuantity));

            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
        }
    }

}
