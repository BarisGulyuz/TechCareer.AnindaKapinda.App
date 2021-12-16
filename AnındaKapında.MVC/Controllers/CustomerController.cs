using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnındaKapında.MVC.Controllers
{
    public class CustomerController : Controller
    {

        [Route("Customer/Adress")]
        public IActionResult Adress()
        {
            return View();
        }

    }
}
