using DespensaBarrialFinal.BD.Datos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialFinal.BD.Datos
{
	public class AplicacionDbContext : DbContext
	{
		public AplicacionDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Administrador> Administrador { get; set; }

        public DbSet<Categorias> Categorias { get; set; }

        public DbSet<Deposito> Deposito { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<Productos> Productos { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }

    }

}