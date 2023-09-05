using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApi.DTo;
using OnlineStoreApi.Models;

namespace OnlineStoreApi.services
{
    //  Classe para el manejo de la interaccion con la base de dato
    //  implementa IUserRepository
    public class UserRepository : IUserRepository
    {
        // constructor que declara el context de la base de dato
        public UserRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; }

        //funcion que retorna todos los usarios
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Context.Users.ToListAsync();
        }

        // funcion que retorna un usuario el la userId  coincida con la id proveeida
        public async Task<User?> GetUser(int id)
        {
            return await Context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        // create un usario
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

        // Elimina un Usario
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

        // actualiza un usuario
        public User UpdateUser(User oldUser, UserDTo updated)
        {
            oldUser.Name = updated.Name;
            oldUser.Email = updated.Email;
            oldUser.Password = HashPassword(updated.Password, oldUser.Salt);
            return oldUser;

        }

        // Authentifiza a el usario
        public async Task<bool> Authenticate(UserLogInDTo request)
        {
            User user = await GetUserByEmail(request.email);

            if(user == null)
            {
                return false;
            }

            var hash = HashPassword(request.password, user.Salt);

            if(hash != user.Password)
            {
                return false;
            }
            return true;
        }

        // covierte password a hash
        public string HashPassword(string password, byte[] salt)
        {
            using var sha256 = SHA256.Create();
            var completedPassword = $"{password}{salt}";

            var byteValue = Encoding.UTF8.GetBytes(completedPassword);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return hash;
        }

        // chekea si un usuario existe
        public async Task<bool> UserExist(int id)
        {
            return await Context.Users.AnyAsync(u => u.Id == id);
        }

        // guarda los cambios de la base de dato
        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync() >= 0);
        }

        // checkea que el email proveido no exita previamente
        public async Task<bool> EmailExist(string email)
        {
            return await Context.Users.AnyAsync(x => x.Email == email);
        }

        // returna al usuario cuyo email coincida con el proveido
        public async Task<User> GetUserByEmail(string email)
        {
            return await Context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

    }
}
