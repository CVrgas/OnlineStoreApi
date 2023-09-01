using OnlineStoreApi.DTo;
using OnlineStoreApi.Models;

namespace OnlineStoreApi.services
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        public Task<Product?> GetProduct(int id);
        public void CreateProduct(Product product);
        public Product UpdateProduct(Product product, ProductDTo updated);
        Task<Product> DeleteProduct(int id);
        public Task<bool> ProductExist(int id);
        public Task<bool> SaveChangesAsync();

    }
}
