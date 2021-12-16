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
    public class AdressController : ControllerBase
    {
        IAdressService _adressService;

        public AdressController(IAdressService adressService)
        {
            _adressService = adressService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _adressService.GetAll();
            return Ok(values);
        }
        [HttpGet]
        [Route("{adressId}")]
        public IActionResult GetbyId(int adressId)
        {
            var value = _adressService.GetById(adressId);
            if (value == null)
            {
                return NotFound(new ApiResponse(404, adressId, message: Messages.NotFound));
            }
            return Ok(value);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deletedValue = _adressService.GetById(id);
            if (deletedValue == null)
            {
                return NotFound(new ApiResponse(404, id, message: Messages.NotFound));
            }
            _adressService.Delete(deletedValue);
            return NoContent();

        }
        [HttpPost]
        [Route("")]
        public IActionResult AddCategory(Adress adress)
        {
            _adressService.Add(adress);
            return Created("", adress);
        }
        [HttpPut]
        [Route("")]
        public IActionResult UpdateCategory(Adress adress)
        {
            var updatedValue = _adressService.GetById(adress.Id);
            if (updatedValue == null)
            {
                return NotFound(new ApiResponse(404, adress.Id, message: Messages.NotFound));
            }
            _adressService.Update(adress);
            return NoContent();
        }
    }
}
