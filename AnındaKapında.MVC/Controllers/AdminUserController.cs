using AnındaKapında.MVC.Models;
using BusinessLayer.Enums;
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
    public class AdminUserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Worker/CargoOfficers")]
        public async Task<IActionResult> CargoOfficers()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:16231/api/Worker/CargoOfficers");

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<WorkerReponseModel>>(jsonData);
                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        [Route("Worker/SupplyOfficers")]
        public async Task<IActionResult> SupplyOfficers()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:16231/api/Worker/SupplyOfficers");

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<WorkerReponseModel>>(jsonData);
                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        [Route("SupplyOfficer/Add")]
        public IActionResult AddSuppyOfficer()
        {
            return View();
        }

        [Route("SupplyOfficer/Add")]
        [HttpPost]
        public async Task<IActionResult> AddSuppyOfficer(WorkerReponseModel model)
        {
            var client = _httpClientFactory.CreateClient();
            model.WorkerTypeId = (int)WorkerTypeEnum.SupplyOfficer;
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:16231/api/Worker", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Worker/SupplyOfficers");
            }
            else
            {
                TempData["errorMessage"] = $"Bir hata ile karşılaşıldı. Hata kodu: {(int)responseMessage.StatusCode}";
                return View(model);
            }
        }

        [Route("CargoOfficer/Add")]
        public IActionResult AddCargoOfficer()
        {
            return View();
        }

        [Route("CargoOfficer/Add")]
        [HttpPost]
        public async Task<IActionResult> AddCargoOfficer(WorkerReponseModel model)
        {
            var client = _httpClientFactory.CreateClient();
            model.WorkerTypeId = (int)WorkerTypeEnum.CargoOfficer;
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:16231/api/Worker", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Worker/CargoOfficers");
            }
            else
            {
                TempData["errorMessage"] = $"Bir hata ile karşılaşıldı. Hata kodu: {(int)responseMessage.StatusCode}";
                return View(model);
            }
        }
    }
}
