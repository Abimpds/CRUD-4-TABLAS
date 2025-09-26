using Microsoft.EntityFrameworkCore;
using Crud_4_Tablas_A_O_M.Models;
namespace CRUD.ModelsCrud_4_Tablas_A_O_M.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetalleVenta> DetallesVentas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
