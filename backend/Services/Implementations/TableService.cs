using Microsoft.EntityFrameworkCore;
using QRRestaurant_backend.Data;
using QRRestaurant_backend.DTOs.QR;
using QRRestaurant_backend.DTOS.Table;
using QRRestaurant_backend.Entities;
using QRRestaurant_backend.Services.Interfaces;

namespace QRRestaurant_backend.Services.Implement
{
    public class TableService : ITableService
    {
        private readonly AppDbContext _context;

        public TableService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TableDto>> GetAllAsync()
        {
            return await _context.Tables
                .Select(t => new TableDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Status = t.Status
                })
                .ToListAsync();
        }

        public async Task<TableDto?> GetByIdAsync(int id)
        {
            return await _context.Tables
                .Where(t => t.Id == id)
                .Select(t => new TableDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Status = t.Status
                })
                .FirstOrDefaultAsync();
        }

        public async Task<QrDto?> GetQrByTableAsync(int tableId)
        {
            return await _context.QRCodes
                .Where(q => q.TableId == tableId)
                .Select(q => new QrDto
                {
                    TableId = q.TableId,
                    Url = q.Url
                })
                .FirstOrDefaultAsync();
        }

        public async Task<QrDto> CreateQrAsync(QrDto dto)
        {
            var qr = new QRCode
            {
                TableId = dto.TableId,
                Url = dto.Url
            };

            _context.QRCodes.Add(qr);
            await _context.SaveChangesAsync();

            return dto;
        }
    }
}
