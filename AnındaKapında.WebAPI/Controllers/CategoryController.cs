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
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _categoryService.GetAll();
            return Ok(values);
        }
        [HttpGet]
        [Route("{categoryId}")]
        public IActionResult GetbyId(int categoryId)
        {
            var value = _categoryService.GetById(categoryId);
            if(value == null)
            {
                return NotFound(new ApiResponse(404, categoryId, message: Messages.NotFound));
            }
            return Ok(value);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deletedValue = _categoryService.GetById(id);
            if (deletedValue == null)
            {
                return NotFound(new ApiResponse(404, id, message: Messages.NotFound));
            }
            _categoryService.Delete(deletedValue);
            return NoContent();

        }
        [HttpPost]
        [Route("")]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.Add(category);
            return Created("", category);
        }
        [HttpPut]
        [Route("")]
        public IActionResult UpdateCategory(Category category)
        {
            var updatedValue = _categoryService.GetById(category.Id);
            if (updatedValue == null)
            {
                return NotFound(new ApiResponse(404, category.Id, message: Messages.NotFound));
            }
           _categoryService.Update(category);
            return NoContent();
        }
    }
}
