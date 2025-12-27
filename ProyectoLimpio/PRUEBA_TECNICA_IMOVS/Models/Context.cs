using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<EstatusTicket> EstatusTickets { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketDetalle> TicketsDetalle { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(p => p.PrecioUnitario)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.TotalTicket)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.MontoPagado)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.MontoPendiente)
                .HasPrecision(18, 2);

            modelBuilder.Entity<TicketDetalle>()
                .Property(td => td.PrecioUnitario)
                .HasPrecision(18, 2);

            modelBuilder.Entity<TicketDetalle>()
                .Property(td => td.TotalFila)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Pago>()
                .Property(p => p.MontoPago)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
                .HasRequired(t => t.UsuarioCreador)
                .WithMany(u => u.TicketsCreados)
                .HasForeignKey(t => t.CreadoPor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pago>()
                .HasRequired(p => p.Usuario)
                .WithMany(u => u.PagosRegistrados)
                .HasForeignKey(p => p.UsuarioId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
