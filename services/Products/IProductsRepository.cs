using OnlineStoreApi.DTo;
using OnlineStoreApi.Models;

namespace OnlineStoreApi.services
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProducts(string? param);
        Task<Product?> GetProduct(int id);
        
        void CreateProduct(Product product);
        Product UpdateProduct(Product product, ProductDTo updated);
        Task<Product> DeleteProduct(int id);
        Task<bool> ProductExist(int id);
        Task<bool> SaveChangesAsync();

    }
}
