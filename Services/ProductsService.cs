using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class ProductsService
    {
        private DataContext _dbContext;

        public ProductsService (DataContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Task<List<Products>> GetProducts()
        {
            return _dbContext.Products.ToListAsync();
        }


        public async Task<Products> singleProduct(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;


        }

        public async Task<List<Products>> addProduct(string Name, string Description, int price, Boolean Status, string Category )
        {
            var product = new Products
            {
                Name = Name,
                Description = Description,
                price = price,
                Category = Category,
                status = false
            };

            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            var products = await _dbContext.Products.ToListAsync();
            return products;
        }
       



        public async Task<List<Products>> updateProducts(int id, Products products)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                product.Name = products.Name;
                product.Description = products.Description;
                product.price = products.price;
                product.Category = products.Category;
                product.status = product.status;

                await _dbContext.SaveChangesAsync();
            }

            return await _dbContext.Products.ToListAsync();


        }


    }
}
