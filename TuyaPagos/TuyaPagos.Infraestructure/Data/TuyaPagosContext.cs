using Microsoft.EntityFrameworkCore;
using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Infraestructure.Data
{
    public class TuyaPagosContext : DbContext
    {
        public TuyaPagosContext()
        {

        }

        public TuyaPagosContext(DbContextOptions<TuyaPagosContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Cliente>(entity =>
            //{
            //    entity.ToTable("Clientes");
            //    entity.HasKey(k => k.Id);
            //    entity.
            //});
        }

        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<DetalleFactura> DetallesFactura { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
    }
}
