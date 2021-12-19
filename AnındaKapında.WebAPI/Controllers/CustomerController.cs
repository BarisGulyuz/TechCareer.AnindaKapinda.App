using BusinessLayer.Enums;
using DataAccessLayer.Context;
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
    public class CustomerController : ControllerBase
    {
        AnındaKapındaContext anındaKapındaContext = new AnındaKapındaContext();
        


        [HttpPost]
        [Route("Register")]
        public IActionResult Register(Customer customer)
        {
            customer.RoleId = (int)(RoleEnum.Member);
            anındaKapındaContext.Add(customer);
            anındaKapındaContext.SaveChanges();
            return Ok(customer);
        }
    }
}
