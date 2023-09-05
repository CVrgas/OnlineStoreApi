using Microsoft.EntityFrameworkCore;
using OnlineStoreApi.Models;

namespace OnlineStoreApi
{
    // El context de la base de dato
    public class DataContext : DbContext
    {
        // data set de usuarios ( tabla de usuarios)
        public DbSet<User> Users { get; set; }

        // data set de productos ( tabla de productos)
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Obtener todas las propiedades de tipo decimal en el modelo de datos.
            var propiedadesDecimales = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            // Configurar la precisión y escala para todas las propiedades decimales.
            foreach (var propiedad in propiedadesDecimales)
            {
                // establecer la precisión en 18 dígitos.
                propiedad.SetPrecision(18);

                // establecer la escala en 2 dígitos.
                propiedad.SetScale(2);
            }
        }
    }
}
