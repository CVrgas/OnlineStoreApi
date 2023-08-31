using OnlineStoreApi.Models;

namespace OnlineStoreApi.services
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        User CreateUser(User user);
        User UpdateUser(int id, User updated);
        void DeleteUser(int id);
        public bool UserExist(int id);
    }
}
