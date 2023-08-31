using System.Security.Cryptography;
using System.Text;
using OnlineStoreApi.Models;

namespace OnlineStoreApi.services
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(tempDb database)
        {
            Database = database;
        }

        public tempDb Database { get; }

        public User CreateUser(User user)
        {
            if(user != null)
            {
                user.Password = HashPassword(user.Password, user.Salt);
                Database.users.Add(user);
            }
            return user;
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            var user = Database.users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return Database.users.ToList();
        }

        public User UpdateUser(int id, User updated)
        {
            throw new NotImplementedException();
        }

        public string HashPassword(string password , byte[] salt)
        {
            using var sha256 = SHA256.Create();
            var completedPassword = $"{password}{salt}";

            var byteValue = Encoding.UTF8.GetBytes(completedPassword);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return hash;
        }
        public bool UserExist(int id)
        {
            return Database.users.Any(x => x.Id == id);
        }

        
    }
}
