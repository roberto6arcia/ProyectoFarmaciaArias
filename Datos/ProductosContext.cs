using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class ProductosContext : DbContext
    {
        public ProductosContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DetalleVenta> DetallesVentas { get; set; }
    }
}