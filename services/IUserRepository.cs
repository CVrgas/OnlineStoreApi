using OnlineStoreApi.DTo;
using OnlineStoreApi.Models;

namespace OnlineStoreApi.services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        public Task<User?> GetUser(int id);
        public void CreateUser(User user);
        public User UpdateUser(User oldUser, UserDTo updated);
        Task<User> DeleteUser(int id);
        public Task<bool> UserExist(int id);
        public Task<bool> EmailExist(string email);
        public Task<bool> SaveChangesAsync();
        public string HashPassword(string password, byte[] salt);
    }
}
