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
    public class CustomerController : Controller
    {


        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Customer/Adress")]
        public IActionResult Adress()
        {
            return View();
        }

        [Route("Customer/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Customer/Register")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:16231/api/Customer/Register", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Customer/Login");
            }
            else
            {
                TempData["errorMessage"] = $"Bir hata ile karşılaşıldı. Hata kodu: {(int)responseMessage.StatusCode}";
                return View(model);
            }
        }

    }
}
