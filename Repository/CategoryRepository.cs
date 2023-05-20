using entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        MyShopSite325593952Context _DbContext;

        public CategoryRepository(MyShopSite325593952Context dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Category> addCategoryAsync(Category category)
        {
            await _DbContext.Categories.AddAsync(category);
            await _DbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> getAllCategoriesAsync()
        {
            return await _DbContext.Categories.ToListAsync();
        }
    }
}
