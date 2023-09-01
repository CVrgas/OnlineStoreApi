using Microsoft.EntityFrameworkCore;
using OnlineStoreApi.DTo;
using OnlineStoreApi.Models;

namespace OnlineStoreApi.services
{
    public class ProductsRepository : IProductsRepository
    {
        public ProductsRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; }
        public async Task<IEnumerable<Product>> GetProducts()

        {
            return await Context.Products.ToListAsync();
        }
        public async Task<Product?> GetProduct(int id)
        {
            return await Context.Products.Where(u => u.Id == id).FirstOrDefaultAsync();

        }

        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                return;
            }
            Context.Products.Add(product);
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var result = await Context.Products.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                Context.Remove(result);
                return result;
            }
            return null;
        }
        public Product UpdateProduct(Product product, ProductDTo updated)
        {
            product.Name = updated.Name;
            product.Description = updated.Description;
            product.Price = updated.Price;
            product.Stock = updated.Stock;
            return product;
        }

        public async Task<bool> ProductExist(int id)
        {
            return await Context.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync() >= 0);
        }

    }
}
