using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRRestaurant_backend.DTOs.Order;
using QRRestaurant_backend.Services.Interfaces;

namespace QRRestaurant_backend.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        //
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var data = await _service.CreateAsync(request);
            return Ok(data);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet("table/{tableId}")]
        public async Task<IActionResult> GetAllByTableId(int tableId)
        {
            var data = await _service.GetAllTableAsync(tableId);
            return Ok(data);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var success = await _service.UpdateStatusAsync(id, status);
            if (!success)
                return NotFound();
            return Ok("updated");
        }
    }
}
