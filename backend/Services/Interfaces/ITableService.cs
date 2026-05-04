using QRRestaurant_backend.DTOs.QR;
using QRRestaurant_backend.DTOS.Table;

namespace QRRestaurant_backend.Services.Interfaces
{
    public interface ITableService
    {
            Task<List<TableDto>> GetAllAsync();
            Task<TableDto?> GetByIdAsync(int id);
            Task<QrDto?> GetQrByTableAsync(int tableId);
            Task<QrDto> CreateQrAsync(QrDto dto);
    }
}
