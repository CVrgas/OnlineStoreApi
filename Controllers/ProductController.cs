using Microsoft.AspNetCore.Mvc;
using OnlineStoreApi.DTo;
using OnlineStoreApi.Models;
using OnlineStoreApi.services;

namespace OnlineStoreApi.Controllers
{
    [Route("OnlineStore/api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        public ProductController(IProductsRepository repository)
        {
            Repository = repository;
        }

        public IProductsRepository Repository { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {
            var products = await Repository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetProduct(int id)
        {
            var product = await Repository.GetProduct(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateProduct(ProductDTo product)
        {
            if(product == null)
            {
                return BadRequest();
            }
            Product newProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
            };

            Repository.CreateProduct(newProduct);
            await Repository.SaveChangesAsync();
            return Ok(newProduct);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductDTo updated)
        {
            if(!await Repository.ProductExist(id))
            {
                return NotFound();
            }
            var product = await Repository.GetProduct(id);
            Repository.UpdateProduct(product, updated);
            await Repository.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteProduct(int id)
        {
            if(!await Repository.ProductExist(id))
            {
                return NotFound();
            }
            var result = await Repository.DeleteProduct(id);
            if(result != null)
            {
                await Repository.SaveChangesAsync();
                return Ok(result);
            }

            return NotFound();
            
        }
    }
}
