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
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasData(new Producto()
                {
                    Id = 1,
                    Nombre = "Tarjeta de Crédito Éxito",
                    Descripcion = "Tarjeta de crédito",
                    PorcentajeImpuesto = 19,
                    Precio = 1000
                }, new Producto()
                {
                    Id = 2,
                    Nombre = "Tarjeta de Crédito Carulla",
                    Descripcion = "Tarjeta de crédito",
                    PorcentajeImpuesto = 0,
                    Precio = 4000
                }, new Producto()
                {
                    Id = 3,
                    Nombre = "Tarjeta de Crédito Alkosto",
                    Descripcion = "Tarjeta de crédito",
                    PorcentajeImpuesto = 10,
                    Precio = 3000
                }, new Producto()
                {
                    Id = 4,
                    Nombre = "Tarjeta de Crédito Claro",
                    Descripcion = "Tarjeta de crédito",
                    PorcentajeImpuesto = 10,
                    Precio = 2000
                });
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(k => k.Cedula);
            });
        }

        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<DetalleFactura> DetallesFactura { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
    }
}
