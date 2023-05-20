using entities;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<Category> addCategoryAsync(Category category);
        Task<IEnumerable<Category>> getAllCategoriesAsync();
    }
}