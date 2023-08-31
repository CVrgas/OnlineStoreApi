using OnlineStoreApi.Models;

namespace OnlineStoreApi
{
    public class tempDb
    {
        public List<User> users = new List<User>();
        public List<Product> products = new List<Product>();
        public static tempDb DbInstance { get; } = new tempDb();

        public tempDb() { 
            users = new List<User>()
            {
                new User { 
                    Id = 1, 
                    Name = "Alice", 
                    Email = "alice@example.com", 
                    Password = "password123" },
                new User { 
                    Id = 2, Name = "Bob", 
                    Email = "bob@example.com", 
                    Password = "securepass" },
                new User { 
                    Id = 3, 
                    Name = "Charlie", 
                    Email = "charlie@example.com", 
                    Password = "p@ssw0rd" },
                new User { 
                    Id = 4, 
                    Name = "David", 
                    Email = "david@example.com", 
                    Password = "davidpass" 
                },
                new User { 
                    Id = 5, 
                    Name = "Eve", 
                    Email = "eve@example.com", 
                    Password = "evesecret" 
                }
            };
            products = new List<Product>()
            {

            };
        }

    }
}
