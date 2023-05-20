using entities;

namespace Service
{
    public interface IProductService
    {
        Task<Product> addProductAsync(Product product);
        Task<IEnumerable<Product>> getProductsWithCategoryAsync();
        Task<IEnumerable<Product>> getProductsBySearch(string? desc, int? minPrice, int? maxPrice, IEnumerable<string>? categoryId);
    }
}