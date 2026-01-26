using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketDetalle> TicketDetalles { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Producto
            modelBuilder.Entity<Producto>()
                .Property(p => p.PrecioUnitario)
                .HasPrecision(18, 2);

            // Configuración de Ticket
            modelBuilder.Entity<Ticket>()
                .Property(t => t.MontoTotal)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.MontoPagado)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Detalles)
                .WithRequired(d => d.Ticket)
                .HasForeignKey(d => d.TicketId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Pagos)
                .WithRequired(p => p.Ticket)
                .HasForeignKey(p => p.TicketId)
                .WillCascadeOnDelete(true);

            // Configuración de TicketDetalle
            modelBuilder.Entity<TicketDetalle>()
                .Property(d => d.PrecioUnitario)
                .HasPrecision(18, 2);

            // Configuración de Pago
            modelBuilder.Entity<Pago>()
                .Property(p => p.Monto)
                .HasPrecision(18, 2);
        }
    }
}