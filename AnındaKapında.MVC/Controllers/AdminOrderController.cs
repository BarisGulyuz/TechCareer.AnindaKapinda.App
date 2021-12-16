using AnındaKapında.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        }
    }

