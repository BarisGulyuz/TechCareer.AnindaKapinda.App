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
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Products")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Product/Details/{id}")]
        public async Task<IActionResult> ProductDetailsAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:16231/api/Product/" + id);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductResponseModel>(jsonData);
                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        [Route("Products/Table")]
        public async Task<IActionResult> GetAllProducts()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:16231/api/Product");

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductResponseModel>>(jsonData);
                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        [Route("Products/Add")]
        public IActionResult Create()
        {
            return View();
        }


        [Route("Products/Add")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductResponseModel model)
        {
            var client = _httpClientFactory.CreateClient();
            model.ImageUrl = "image";
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:16231/api/Product", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Products/Table");
            }
            else
            {
                TempData["errorMessage"] = $"Bir hata ile karşılaşıldı. Hata kodu: {(int)responseMessage.StatusCode}";
                return View(model);
            }
        }


        [Route("Categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:16231/api/Category");

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<CategoryResponseModel>>(jsonData);
                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        [Route("Products/Basket/{productName}/{price}")]
        [HttpPost]
        public async Task<IActionResult> Basket(BasketResponseModel basket, string productName, decimal price)
        {


            var client = _httpClientFactory.CreateClient();
            basket.Items.Add(new BasketItemsResponseModel
            {
                Quantity = 1,
                ProductName = productName,
                Price = price
            });
            var jsonData = JsonConvert.SerializeObject(basket);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5000/api/products", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                //return Redirect("Index");
                return View();
            }
            else
            {
                return View(basket);
            }
        }

        [Route("Product/Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("http://localhost:16231/api/Product/" + id);
            return Redirect("/Products/Table");
        }

    }
}
