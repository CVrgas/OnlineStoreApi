using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApi.Models;
using OnlineStoreApi.services;

namespace OnlineStoreApi.Controllers
{
    [Route("OnlineStore/api/user")]
    [ApiController]
    public class UserController : Controller
    {
        public UserController(IUserRepository repository)
        {
            Repository = repository;
        }

        public IUserRepository Repository { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = Repository.GetUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (Repository.UserExist(id))
            {
                var user = Repository.GetUser(id);
                return Ok(user);
            }
            return BadRequest(); 
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(User newUser)
        {
            var user = Repository.CreateUser(newUser);
            return Ok(user);
                
        }
    }
}
