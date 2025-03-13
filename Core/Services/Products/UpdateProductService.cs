using BusinessEntities;
using Common;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
        public void Update(Product product, string name, string description, decimal price, int stockQuantity)
        {
            if(name != null)
            {
                product.Name = name;
            }

            if (description != null)
            {
                product.Description = description;
            }

            product.StockQuantity = stockQuantity;
        }
    }
}
