using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApi.DTo;
using OnlineStoreApi.Models;
using OnlineStoreApi.services;

namespace OnlineStoreApi.Controllers
{
    // controlador de productos, este recive las request y responde relacionas con productos
    [Route("OnlineStore/api/user")]
    [ApiController]
    public class UserController : Controller
    {
        public UserController(IUserRepository repository, JwtService jwtService)
        {
            Repository = repository;
            JwtService = jwtService;
        }

        public IUserRepository Repository { get; }
        public JwtService JwtService { get; }

        // responde a las solicitudes HTTP Get para obtener todos los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await Repository.GetUsers();
            return Ok(users);
        }

        // responde a las solicitudes HTTP Get para obtener
        // usurio cuyo id sea igual al id proporcionado
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await Repository.GetUser(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // responde a la solicitudes HTTP Post 
        // para crear usuarios
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UserDTo user)
        {
            // revisa que el email no exista
            if(await Repository.EmailExist(user.Email))
            {
                // si existe retorna http 400
                return BadRequest("email already exist");
            }
            // crea nuevo usario
            User newUser = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Salt = RandomNumberGenerator.GetBytes(128 / 8),
                
            };
            // le agrega la contrasena Hashed
            // lo crea, guarda cambios y responde con http 200
            newUser.Password = Repository.HashPassword(user.Password, newUser.Salt);
            Repository.CreateUser(newUser);
            await Repository.SaveChangesAsync();
            return Ok(newUser);
                
        }
        
        // responde a la solicitudes HTTp put
        // para editar el usuario
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTo newUser)
        {
            // revisa si exite el usuario
            if(!await Repository.UserExist(id))
            {
                // responde con http 404 si no existe
                return NotFound();
            }
            // busca al usuario el cual sera editado
            // 
            var oldUser = await Repository.GetUser(id);
            // Edita el usurio
            Repository.UpdateUser(oldUser, newUser);
            // guarda cambio y responde con http 200
            await Repository.SaveChangesAsync();
            return Ok(oldUser);
        }

        // responde a las solicitudes http delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)    
        {
            // revisa que el usuario exista y que no sea null
            if(!await Repository.UserExist(id) || await Repository.GetUser(id) == null)
            {
                // responde con http 404
                return NotFound();
            }
            // elimina al usurio
            var result = await Repository.DeleteUser(id);
            // revisa que fue eliminado
            if(result != null)
            {
                // guarda cambios y responde con http 200
                await Repository.SaveChangesAsync();
                return Ok(result);

            }
            // responde con http 404
            return NotFound();
            
        }

        // responde a las solicitudes http Post
        // en la ruta /authenticate
        // autentificar a los usarios 
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate(UserLogInDTo request)
        {
            // si el usario no es valido
            if(!await Repository.Authenticate(request))
            {
                // responde con 404 
                return NotFound(request);
            }
            // crea un token 
            var token = JwtService.GenerateToken(request.email);
            // responde con el token
            return Ok(new {token});
        }
    }
}
