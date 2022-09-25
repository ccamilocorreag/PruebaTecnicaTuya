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
            #region Configuración Cliente

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes")
                .HasMany(m => m.Facturas)
                .WithOne(x => x.ClienteFk)
                .HasForeignKey(f => f.ClienteId)
                .IsRequired();

                entity.Property(s => s.Id)
                .UseIdentityColumn()
                .IsRequired();

                entity.Property(p => p.Cedula)
                .HasMaxLength(10)
                .IsRequired();

                entity.Property(p => p.Nombres)
                .HasMaxLength(60)
                .IsRequired();

                entity.Property(p => p.Apellidos)
                .HasMaxLength(60)
                .IsRequired();
            });

            #endregion

            #region Configuración Producto

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos")
                .HasMany(m => m.DetalleFactura)
                .WithOne(o => o.ProductoFk)
                .HasForeignKey(f => f.ProductoId)
                .IsRequired();

                entity.Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();

                entity.Property(p => p.Descripcion)
                .HasMaxLength(250);

                entity.Property(p => p.Nombre)
                .HasMaxLength(60)
                .IsRequired();

                entity.Property(p => p.Precio)
                .IsRequired();

                entity.Property(p => p.PorcentajeImpuesto)
                .IsRequired();

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

            #endregion

            #region Configuración Factura

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Facturas")
                .HasMany(m => m.DetalleFactura)
                .WithOne(o => o.FacturaFk)
                .HasForeignKey(f => f.FacturaId)
                .IsRequired();

                entity
                .HasMany(m => m.Pedidos)
                .WithOne(o => o.FacturaFk)
                .HasForeignKey(f => f.FacturaId)
                .IsRequired();

                entity.HasOne(o => o.ClienteFk)
                .WithMany(m => m.Facturas)
                .HasForeignKey(f => f.ClienteId)
                .IsRequired();

                entity.Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();

                entity.Property(p => p.Fecha)
                .IsRequired();

                entity.Property(p => p.ClienteId)
                .IsRequired();

                entity.Property(p => p.ValorBruto)
                .IsRequired();

                entity.Property(p => p.Impuesto)
                .IsRequired();

                entity.Property(p => p.ValorNeto)
                .IsRequired();

                entity.Property(p => p.Observaciones)
                .HasMaxLength(250);
            });

            #endregion

            #region Configuracion Detalle Factura

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.ToTable("DetalleFactura")
                .HasOne(o => o.FacturaFk)
                .WithMany(m => m.DetalleFactura)
                .HasForeignKey(f => f.FacturaId)
                .IsRequired();

                entity.HasOne(o => o.ProductoFk)
                .WithMany(m => m.DetalleFactura)
                .HasForeignKey(f => f.ProductoId)
                .IsRequired();

                entity.Property(p => p.Id)
                .UseIdentityColumn();

                entity.Property(p => p.Cantidad)
                .IsRequired();

                entity.Property(p => p.ValorBruto)
                .IsRequired();

                entity.Property(p => p.ValorNeto)
                .IsRequired();

                entity.Property(p => p.Impuesto)
                .IsRequired();
            });

            #endregion

            #region Configuracion Pedido

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedidos")
                .HasOne(o => o.FacturaFk)
                .WithMany(m => m.Pedidos)
                .HasForeignKey(f => f.FacturaId)
                .IsRequired();

                entity.Property(p => p.Id)
                .UseIdentityColumn();

                entity.Property(p => p.Fecha)
                .IsRequired();

                entity.Property(p => p.Direccion)
                .HasMaxLength(150)
                .IsRequired();

                entity.Property(p => p.Ciudad)
                .HasMaxLength(60)
                .IsRequired();

                entity.Property(p => p.Departamento)
                .HasMaxLength(60)
                .IsRequired();

                entity.Property(p => p.Estado)
                .HasMaxLength(20)
                .IsRequired();
            });

            #endregion
        }

        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<DetalleFactura> DetallesFactura { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
    }
}
