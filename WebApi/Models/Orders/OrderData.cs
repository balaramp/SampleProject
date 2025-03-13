using BusinessEntities;
using System.Collections.Generic;
using System;
using System.Linq;
using WebApi.Models.Orders;

public class OrderData
{
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public List<OrderItemData> Items { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public OrderData(Order order)
    {
        OrderId = order.Id;
        UserId = order.UserId;
        Items = order.Items.Select(item => new OrderItemData(item)).ToList();
        TotalAmount = order.TotalAmount;
        Status = order.Status.ToString();
        CreatedAt = order.CreatedAt;
    }
}


