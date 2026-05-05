using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRRestaurant_backend.DTOs.Product;
using QRRestaurant_backend.Entities;
using QRRestaurant_backend.Services.Interfaces;

namespace QRRestaurant_backend.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        //Get: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }


        //Get: api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        //Get: api/products/category/{Id}
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var data = await _service.GetByCategoryAsync(categoryId);
            return Ok(data);
        }

        //Get: api/products/searchCategory
        [HttpGet("search")]
        public async Task<IActionResult> SearchCategory(string keyword)
        {
            var data = await _service.SearchAsync(keyword);
            return Ok(data);
        }

        //POST: api/products/searchCategory
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateProductDto dto)
        {
            var data = await _service.CreateAsync(dto);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success)
                return NotFound();
            return Ok("updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var ok = await _service.DeleteAsync(Id);
            if (!ok) return NotFound();
            return Ok("Delete");
        }
    } 

}
