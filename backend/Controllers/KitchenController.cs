using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRRestaurant_backend.Services.Interfaces;

namespace QRRestaurant_backend.Controllers
{
    [Route("api/kitchen")]
    [ApiController]
    public class KitchenController : ControllerBase
    {
        private readonly IKitchenService _service;

        public KitchenController(IKitchenService service)
        {
            _service = service;
        }
        // GET: api/kitchen
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            return Ok(await _service.GetPendingItemsAsync());
        }

        // PUT: api/kitchen/1/status?status=Preparing
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var ok = await _service.UpdateStatusAsync(id, status);
            if (!ok) return NotFound();

            return Ok("Updated");
        }
    }
}
