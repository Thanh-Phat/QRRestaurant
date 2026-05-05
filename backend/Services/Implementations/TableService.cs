using Microsoft.EntityFrameworkCore;
using QRRestaurant_backend.Data;
using QRRestaurant_backend.DTOs.QR;
using QRRestaurant_backend.DTOs.Table;
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
            var baseUrl = "https://localhost:3000";

            return await _context.Tables
                .Select(t => new TableDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Status = t.Status,
                    QrUrl = $"{baseUrl}/menu?tableId={t.Id}"
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

        public async Task<TableDto> CreateTableAsync(TableCreateDto dto)
        {
            var table = new Table
            {
                Name = dto.Name,
                Status = "Empty",
                CreatedAt = DateTime.Now
            };

            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            // Sau khi tạo xong bàn, tự động tạo QR code cho bàn đó
            var baseUrl = "https://localhost:3000";
            var qrUrl = $"{baseUrl}/menu?tableId={table.Id}";

            return new TableDto
            {
                Id = table.Id,
                Name = table.Name,
                Status = table.Status,
                QrUrl = qrUrl
            };
        }

        public async Task<bool> UpdateAsync(int id, TableUpdateDto dto)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return false;

            table.Name = dto.Name;
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return false;

            // ❗ không cho xoá nếu đang có order
            var hasOrder = await _context.Orders.AnyAsync(o => o.TableId == id);
            if (hasOrder) return false;

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return true;
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
