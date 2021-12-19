using AnındaKapında.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnındaKapında.MVC.Controllers
{
    public class AdminOrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminOrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Orders")]
        public async Task<IActionResult> Orders()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:16231/api/Order");

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<OrderResponseModel>>(jsonData);
                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        [Route("Orders/Lines/{orderId}")]
        public async Task<IActionResult> OrderLines(int orderId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:16231/api/Order/OrderLine/" + orderId);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<OrderLineResponseModel>>(jsonData);
                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        [Route("Orders/Adress/{id}")]
        public async Task<IActionResult> OrderAdress(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:16231/api/Adress/" + id);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AdressResponseModel>(jsonData);
                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        [Route("Orders/Update/{id}")]
        public IActionResult OrderUpdate(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [Route("Orders/Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> OrderUpdate(OrderUpdateResponeModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:16231/api/Order", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Orders");
            }
            else
            {
                return View(model);
            }
        }


    }


}

