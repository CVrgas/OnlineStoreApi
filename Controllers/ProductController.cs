using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApi.DTo;
using OnlineStoreApi.Models;
using OnlineStoreApi.services;

namespace OnlineStoreApi.Controllers
{
    // controlador de productos, este recive las request y responde relacionas con productos
    [Authorize] // encesitas tener un toke para acceder a este
    [Route("OnlineStore/api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        // constructo 
        public ProductController(IProductsRepository repository, JwtService jwtService)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // propiedad para accderder al repositorio de productos
        public IProductsRepository Repository { get; }

        // responde a las solicitudes HTTP Get para obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {
            // obttiene los productos
            var products = await Repository.GetProducts(); 
            // responde con unHTTP 200
            return Ok(products);
        }

        // responde a las solicitudes HTTP Get para obtener todos los productos
        // productos que coincidan con el query
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct([FromQuery]string param)
        {
            // obttiene los productos
            var products = await Repository.GetProducts(param);
            // responde con unHTTP 200
            return Ok(products);
        }
        
        // responde a las solicitudes HTTP Get para obtener producto que cumpla la condicion
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // Obtiene producto que id es igual al id proveído
            var product = await Repository.GetProduct(id);

            // si no se encontro returna HTTP 404
            if(product == null)
            {
                return NotFound();
            }
            // si existe retona HTTP 200
            return Ok(product);
        }

        // responde solicitudes http Post para crear producto
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(ProductDTo product)
        {
            // si el producto proporcionado es nulo
            // responde con HTTP 400
            if(product == null)
            {
                return BadRequest();
            }
            // crea un nuevo producto
            Product newProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Thumbnail = product.Thumbnail,
                ImagesUrl = product.ImagesUrl,
                Brand = product.Brand,
                Price = product.Price,
                Stock = product.Stock,
            };
            // agrega el producto ala base de dato
            //guarda cambios 
            //retorna el mismo prodcuto
            Repository.CreateProduct(newProduct);
            await Repository.SaveChangesAsync();
            return Ok(newProduct);
        }

        // responde a solicitudes http put, para editar un producto
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductDTo updated)
        {
            // revisa si el producto existe 
            if(!await Repository.ProductExist(id))
            {
                // respodne http 400 si no eexiste
                return NotFound();
            }
            // bsuca el producto 
            var product = await Repository.GetProduct(id);
            // actualiza el producto
            Repository.UpdateProduct(product, updated);
            //guarda lso vambios y responde con Http 200
            await Repository.SaveChangesAsync();
            return Ok(product);
        }

        // responde a las solicitudes http delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            // revisa que el producto exista
            if(!await Repository.ProductExist(id))
            {
                // no exites retorna un http 404
                return NotFound();
            }
            // elimina el producto
            var result = await Repository.DeleteProduct(id);

            // confima que fue eliminado
            if(result != null)
            {
                //guarda cambios y returna http 200
                await Repository.SaveChangesAsync();
                return Ok(result);
            }

            // responde con http 404
            return NotFound();
            
        }
    }
}
