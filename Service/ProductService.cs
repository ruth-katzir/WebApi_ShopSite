using entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Product> addProductAsync(Product product)
        {
            return await repository.addProductAsync(product);
        }
        public async Task<IEnumerable<Product>> getProductsWithCategoryAsync()
        {
            return await repository.getProductsWithCategoryAsync();
        }

        public async Task<IEnumerable<Product>> getProductsBySearch(string? desc, int? minPrice, int? maxPrice, IEnumerable<string>? categoryId)
        {
            return await repository.getProductsBySearch(desc, minPrice, maxPrice, categoryId);
        }


    }
}
