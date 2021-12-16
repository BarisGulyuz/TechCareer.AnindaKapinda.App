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

        [Route("Products/Basket")]
        public async Task<IActionResult> Basket()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:16231/api/Basket/GetBasket?basketId=e603fce3-0343-4390-9a87-deecb50f2ac4");

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BasketResponseModel>(jsonData);
                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        //[HttpPost]
        //[Route("AddToCart")]
        //public async Task<IActionResult> Index(string productName, decimal price)
        //{

        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(basket);
        //    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PutAsync("http://localhost:16231/api/Basket", content);

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return BadRequest();
        //}

    }
}




//[HttpPost]
//public async Task<IActionResult> Create(ProductResponseModel model)
//{
//    var client = _httpClientFactory.CreateClient();
//    var jsonData = JsonConvert.SerializeObject(model);
//    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
//    var responseMessage = await client.PostAsync("http://localhost:5000/api/products", content);

//    if (responseMessage.IsSuccessStatusCode)
//    {
//        return RedirectToAction("Index");
//    }
//    else
//    {
//        TempData["errorMessage"] = $"Bir hata ile karşılaşıldı. Hata kodu: {(int)responseMessage.StatusCode}";
//        return View(model);
//    }
//}

//public async Task<IActionResult> Update(int id)
//{
//    var client = _httpClientFactory.CreateClient();
//    var responseMessage = await client.GetAsync($"http://localhost:5000/api/products/{id}");
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        var jsonData = await responseMessage.Content.ReadAsStringAsync();
//        var data = JsonConvert.DeserializeObject<ProductResponseModel>(jsonData);
//        return View(data);
//    }

//    else
//    {
//        return View(null);
//    }
//}

//[HttpPost]
//public async Task<IActionResult> Update(ProductResponseModel model)
//{
//    var client = _httpClientFactory.CreateClient();
//    var jsonData = JsonConvert.SerializeObject(model);
//    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
//    var responseMessage = await client.PutAsync("http://localhost:5000/api/products", content);
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        return RedirectToAction("Index");
//    }
//    else
//    {
//        return View(model);
//    }
//}


//public async Task<IActionResult> Remove(int id)
//{
//    var client = _httpClientFactory.CreateClient();
//    await client.DeleteAsync($"http://localhost:5000/api/products/{id}");
//    return RedirectToAction("Index");
//}

//public IActionResult Upload()
//{
//    return View();
//}
