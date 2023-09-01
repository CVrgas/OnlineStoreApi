using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApi.DTo;
using OnlineStoreApi.Models;

namespace OnlineStoreApi.services
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Context.Users.ToListAsync();
        }
        public async Task<User?> GetUser(int id)
        {
            return await Context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public void CreateUser(User user)
        {
            //User newUser = new User()
            //{
            //    Name = user.Name,
            //    Email = user.Email,
            //    Salt = RandomNumberGenerator.GetBytes(128 / 8),
            //};
            //newUser.Password = HashPassword(user.Password, newUser.Salt);
           
            Context.Users.Add(user);
        }

        public async Task<User> DeleteUser(int id)
        {
            var result = await Context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if(result != null)
            {
                Context.Remove(result);
                return result;
            }
            return null;
        }

        public User UpdateUser(User oldUser, UserDTo updated)
        {
            oldUser.Name = updated.Name;
            oldUser.Email = updated.Email;
            oldUser.Password = HashPassword(updated.Password, oldUser.Salt);
            return oldUser;

        }

        public string HashPassword(string password, byte[] salt)
        {
            using var sha256 = SHA256.Create();
            var completedPassword = $"{password}{salt}";

            var byteValue = Encoding.UTF8.GetBytes(completedPassword);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return hash;
        }
        public async Task<bool> UserExist(int id)
        {
            return await Context.Users.AnyAsync(u => u.Id == id);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync() >= 0);
        }
        public async Task<bool> EmailExist(string email)
        {
            return await Context.Users.AnyAsync(x => x.Email == email);
        }

    }
}
