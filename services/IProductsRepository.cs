using OnlineStoreApi.Models;

namespace OnlineStoreApi.services
{
    public interface IProductsRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public IEnumerable<Product> GetProductsByOption(string opt);
        public Product GetProduct(int productId);
        public Product CreateProduct(Product product);
        public Product UpdateProduct(Product product);
        public void DeleteProduct(int productId);
        public bool ProductExist();

         
    }
}
