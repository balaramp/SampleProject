using System.Net.Http;
using System;
using System.Web.Http;
using Core.Services.Orders;
using Core.Services.Users;
using WebApi.Models.Orders;
using System.Collections.Generic;
using BusinessEntities;
using System.Linq;
using System.Net;
using Core.Services.Products;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IGetUserService _getUserService;
        private readonly IGetProductService _getProductService;
        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService,
                                    IGetUserService getUserService, IGetProductService getProductService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
            _getUserService = getUserService;
            _getProductService = getProductService;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Order data is required.");
            }

            if (model.UserId == Guid.Empty)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Valid UserId is required.");
            }

            if (model.Items == null || !model.Items.Any())
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "At least one order item is required.");
            }

            try
            {
                // Retrieve user
                var user = _getUserService.GetUser(model.UserId);
                if (user == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found.");
                }

                // Create order items
                var orderItems = new List<OrderItem>();
                foreach (var item in model.Items)
                {
                    var product = _getProductService.GetProduct(item.ProductId);
                    if (product == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Product with ID {item.ProductId} not found.");
                    }

                    orderItems.Add(new OrderItem(item.ProductId, item.Quantity));
                }

                // Create Order
                var order = _createOrderService.Create(orderId, model.UserId, orderItems, model.TotalAmount, model.Status);

                // Return success response
                return Found(new OrderData(order));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while creating the order: " + ex.Message);
            }
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Order data is required.");
            }

            if (model.UserId == Guid.Empty)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Valid UserId is required.");
            }

            if (model.Items == null || !model.Items.Any())
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "At least one order item is required.");
            }

            try
            {
                // Retrieve existing order
                var order = _getOrderService.GetOrder(orderId);
                if (order == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Order not found.");
                }

                // Retrieve user
                var user = _getUserService.GetUser(model.UserId);
                if (user == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found.");
                }

                // Validate order items
                var orderItems = new List<OrderItem>();
                foreach (var item in model.Items)
                {
                    var product = _getProductService.GetProduct(item.ProductId);
                    if (product == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Product with ID {item.ProductId} not found.");
                    }

                    orderItems.Add(new OrderItem(item.ProductId, item.Quantity));
                }

                // Update order details
                _updateOrderService.Update(order, model.UserId, orderItems, model.TotalAmount, model.Status);

                // Return success response
                return Found(new OrderData(order));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while updating the order: " + ex.Message);
            }
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            try
            {
                var order = _getOrderService.GetOrder(orderId);
                if (order == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Order not found.");
                }

                return Found(new OrderData(order));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while retrieving the order: " + ex.Message);
            }
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(int skip = 0, int take = 10)
        {
            try
            {
                var orders = _getOrderService.GetOrders()
                                             .Skip(skip)
                                             .Take(take)
                                             .Select(o => new OrderData(o))
                                             .ToList();

                return Found(orders);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while retrieving orders: " + ex.Message);
            }
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            try
            {
                var order = _getOrderService.GetOrder(orderId);
                if (order == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Order not found.");
                }

                _deleteOrderService.Delete(order);
                return Found();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while deleting the order: " + ex.Message);
            }
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllOrders()
        {
            try
            {
                _deleteOrderService.DeleteAll();
                return Found();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while clearing orders: " + ex.Message);
            }
        }

        [Route("list/userId")]
        [HttpGet]
        public HttpResponseMessage GetOrderByUser(Guid userId)
        {
            try
            {
                var orders = _getOrderService.GetOrdersByUser(userId);
                return Found(orders);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while retrieving orders by user: " + ex.Message);
            }
        }
    }
}