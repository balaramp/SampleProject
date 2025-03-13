using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity {  get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
