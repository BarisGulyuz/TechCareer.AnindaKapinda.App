using EntityLayer.Concrete;
using BusinessLayer.Abstract;
using EntityLayer.Concrete.BasketEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Context;

namespace AnındaKapında.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        IBasketService _basketRepository;

        public BasketController(IBasketService basketRepository)
        {
            _basketRepository = basketRepository;
        }
        [HttpGet]
        [Route("GetBasket")]
        public async Task<ActionResult> GetBasket(string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);
            return Ok(basket ?? new Basket(basketId));
        }
        [HttpPut]
        public async Task<ActionResult> UpdateBasket(Basket basket)
        {
            if (basket.Id == null)
            {
                var basketGuid = Guid.NewGuid();
                basket.Id = basketGuid.ToString();
            }
            var updatedBasket = await _basketRepository.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }
        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }

        [HttpPost]
        [Route("Ckechout")]
        public async  Task<IActionResult> Checkout(string id, Order order)
        {
            AnındaKapındaContext context = new AnındaKapındaContext();
            context.Orders.Add(order);
            context.SaveChanges();
            var basket = await _basketRepository.GetBasketAsync(id);
            order.OrderLines = new List<OrderLine>();
            foreach (var item in basket.Items)
            {
                OrderLine orderLine = new();
                orderLine.ProductName = item.ProductName;
                orderLine.Quantity = item.Quantity;
                orderLine.Price = item.Price;
                orderLine.OrderId = order.Id;

                context.OrderLines.Add(orderLine);
                context.SaveChanges();
            }
            return Ok();
           
        }

    }
}
