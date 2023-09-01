using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApi.DTo;
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
            var users = await Repository.GetUsers();
            return Ok(users);
        } 
        
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

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UserDTo user)
        {
            if(await Repository.EmailExist(user.Email))
            {
                return BadRequest();
            }
            User newUser = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Salt = RandomNumberGenerator.GetBytes(128 / 8),
                
            };
            newUser.Password = Repository.HashPassword(user.Password, newUser.Salt);
            Repository.CreateUser(newUser);
            await Repository.SaveChangesAsync();
            return Ok(newUser);
                
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTo newUser)
        {
            if(!await Repository.UserExist(id))
            {
                return NotFound();
            }
            var oldUser = await Repository.GetUser(id);
            Repository.UpdateUser(oldUser, newUser);
            await Repository.SaveChangesAsync();
            return Ok(oldUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)    
        {
            
            if(!await Repository.UserExist(id) || await Repository.GetUser(id) == null)
            {
                return NotFound();
            }

            var result = await Repository.DeleteUser(id);
            if(result != null)
            {
                await Repository.SaveChangesAsync();
                return Ok(result);

            }
            return NotFound();
            
        }
    }
}
