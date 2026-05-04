using QRRestaurant_backend.DTOs.Product;

namespace QRRestaurant_backend.Services.Interfaces
{
    public interface IProductService  
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<List<ProductDto>> GetByCategoryAsync(int categoryId);
        Task<List<ProductDto>> SearchAsync(string keyword);
    }
}
