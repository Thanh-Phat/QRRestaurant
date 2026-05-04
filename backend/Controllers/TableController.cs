using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using QRRestaurant_backend.DTOs.QR;
using QRRestaurant_backend.Services.Interfaces;

namespace QRRestaurant_backend.Controllers
{
    [Route("api/tables")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _service;

        public TableController(ITableService service)
        {
            _service = service;
        }

        //Get: api/tables
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        //Get: api/tables/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        //Get: api/tables/{id}/qr
        [HttpGet("{id}/qr")]
        public async Task<IActionResult> GetByTableId(int id)
        {
            var data = await _service.GetQrByTableAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        //Post: api/tables/qr
        [HttpPost("qr")]
        public async Task<IActionResult> CreateQr(QrDto dto)
        {
            var result = await _service.CreateQrAsync(dto);
            return Ok(result);  
        }
    }
}
