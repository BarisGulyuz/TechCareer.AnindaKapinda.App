using AnındaKapında.WebAPI.Constans;
using BusinessLayer.Abstract;
using BusinessLayer.ErrorResponse;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnındaKapında.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        IOrderLineService _orderLineService;

        public OrderController(IOrderService orderService, IOrderLineService orderLineService)
        {
            _orderService = orderService;
            _orderLineService = orderLineService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetOrders()
        {
           var order = _orderService.GetAll();
            return Ok(order);
        }
        [HttpGet]
        [Route("OrderLine/{orderId}")]
        public IActionResult GetOrders(int orderId)
        {
            var value = _orderLineService.GetOrderLinesbyOrder(orderId);
            if (value.Count <=0)
            {
                return NotFound(new ApiResponse(404, orderId, message: Messages.NotFound));
            }
            return Ok(value);
        }

        [HttpPut]
        [Route("")]
        public IActionResult UpdateOrder(Order order)
        {
            var updatedValue = _orderService.GetById(order.Id);
            order.AdressId = updatedValue.AdressId;
            order.CustomerName = updatedValue.CustomerName;
            order.OrderDate = updatedValue.OrderDate;
            if (updatedValue == null)
            {
                return NotFound(new ApiResponse(404, order.Id, message: Messages.NotFound));
            }
            _orderService.Update(order);
            return NoContent();
        }
    }
}
