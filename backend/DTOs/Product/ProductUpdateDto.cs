namespace QRRestaurant_backend.DTOs.Product
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int?  CategoryId { get; set; }
    }
}
