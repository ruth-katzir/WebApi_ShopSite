using entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : ICategoryService
    {

        ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Category> addCategoryAsync(Category category)
        {
            return await repository.addCategoryAsync(category);
        }

        public async Task<IEnumerable<Category>> getAllCategoriesAsync()
        {
            return await repository.getAllCategoriesAsync();
        }
    }
}
