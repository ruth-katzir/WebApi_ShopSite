using entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<Product> addProductAsync(Product product);
        Task<IEnumerable<Product>> getProductsWithCategoryAsync();
        Task<IEnumerable<Product>> getProductsBySearch(string? desc, int? minPrice, int? maxPrice, IEnumerable<string>? categoryId);
        Task<int> getProductPriceByProductId(int price);
    }
}