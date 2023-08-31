using Microsoft.AspNetCore.Mvc;
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
            var products = Repository.GetAllProducts();
            return Ok(products);
        }
    }
}
