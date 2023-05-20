using entities;

namespace Service
{
    public interface ICategoryService
    {
        Task<Category> addCategoryAsync(Category category);
        Task<IEnumerable<Category>> getAllCategoriesAsync();
    }
}