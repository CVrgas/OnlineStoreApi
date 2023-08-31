using Microsoft.EntityFrameworkCore;
using OnlineStoreApi.Models;

namespace OnlineStoreApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
