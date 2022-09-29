using DespensaBarrialFinal.BD.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialFinal.BD
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Proveedores> Proveedores { get; set; }

        public DbSet<Productos> Productos { get; set; }

        public DbSet<Logs> Logs { get; set; }

        public DbSet<Categorias> Categorias { get; set; }

        public DbSet<Deposito> Deposito { get; set; }

        public DbSet<ProveedorProducto> ProveedorProducto { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}