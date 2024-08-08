using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ProductsInterface
    {
        Task<List<Products>>getProducts();

        Task<List<Products>>addProducts(string Nmes, string Description, string Category, int price );

        Task<List<Products>>updateProducts(int id, Products products);

        Task<List<Products>>deleteProducts( int id);

        Task<List<Products>>singleProduct( int id);
    }
}
