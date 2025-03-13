using System;
using System.Collections.Generic;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public Guid UserId { get; set; }
        public IEnumerable<OrderItemModel> Items { get; set; }
        public string Status { get; set; }
        public int TotalAmount {  get; set; }   
    }
}