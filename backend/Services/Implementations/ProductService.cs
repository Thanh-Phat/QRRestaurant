using Microsoft.EntityFrameworkCore;
using QRRestaurant_backend.Data;
using QRRestaurant_backend.DTOs.Product;
using QRRestaurant_backend.Entities;
using QRRestaurant_backend.Services.Interfaces;

namespace QRRestaurant_backend.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        //Get all active products with category name
        public async Task<List<ProductDto>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category.Name != null ? p.Category.Name : ""
                })
                .ToListAsync();
        }

        //Get product by id
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Id == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category.Name != null ? p.Category.Name : ""
                })
                .FirstOrDefaultAsync();
        }

        //Get products by category
        public async Task<List<ProductDto>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId && p.IsActive)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category.Name != null ? p.Category.Name : ""
                })
                .ToListAsync();
        }

        //Search products by name (case-insensitive)
        public async Task<List<ProductDto>> SearchAsync(string keyword)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Name.ToLower().Contains(keyword.ToLower()) && p.IsActive)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category.Name != null ? p.Category.Name : ""
                })
                .ToListAsync();
        }

        //Create new product
        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId,
                IsActive = true
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryName = ""
            };
        }

        //Update product details
        public async Task<bool> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null) return false;

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.ImageUrl = dto.ImageUrl;
            product.CategoryId = dto.CategoryId;
            
            await _context.SaveChangesAsync();
            return true;

        }

        //Soft delete: set IsActive to false instead of removing from database
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            product.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }

        //
    }
}
