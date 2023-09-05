using Microsoft.EntityFrameworkCore;
using OnlineStoreApi.DTo;
using OnlineStoreApi.Models;

namespace OnlineStoreApi.services
{
    //classe para el manejo de la interaccion con la base de dato
    // implementa IProductsRepository
    public class ProductsRepository : IProductsRepository
    {
        // constructor que declara el context de la base de dato
        public ProductsRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; }

        // funcion que retorna todo los productos
        public async Task<IEnumerable<Product>> GetProducts()

        {
            return await Context.Products.ToListAsync();
        }
        //funcion que retorna todos los productos que contengan el parametro
        public async Task<IEnumerable<Product>> GetProducts(string? param)
        {
            if (param == null)
            {
                return new List<Product>();
            }
            var paramLower = param.ToLower();
            return await Context.Products.Where(p => p.Name.ToLower().Contains(paramLower) || 
                                                p.Description.ToLower().Contains(paramLower) ||
                                                p.Brand.ToLower().Contains(paramLower))
                                                .ToListAsync();
        }
        
        //funcion que retorna un producto con el que coincida su id
        public async Task<Product?> GetProduct(int id)
        {
            return await Context.Products.Where(u => u.Id == id).FirstOrDefaultAsync();

        }

        // funcion que crea un producto
        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                return;
            }
            Context.Products.Add(product);
        }

        // funcion que elimina un producto
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

        //funcion que actualiza un producto
        public Product UpdateProduct(Product product, ProductDTo updated)
        {
            product.Name = updated.Name;
            product.Description = updated.Description;
            product.Price = updated.Price;
            product.Stock = updated.Stock;
            return product;
        }

        // funcion para chekear que exista el producto usando un id
        public async Task<bool> ProductExist(int id)
        {
            return await Context.Products.AnyAsync(p => p.Id == id);
        }

        // Funcion para guardar los cambios de la base de dato
        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync() >= 0);
        }


    }
}
