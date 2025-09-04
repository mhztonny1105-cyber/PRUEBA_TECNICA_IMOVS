using System.Data.Entity;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class PagosContext : DbContext
    {
        public PagosContext() : base("PagosContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PagosContext>());
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<DetalleTicket> DetallesTicket { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleTicket>()
                .HasRequired(dt => dt.Ticket)
                .WithMany(t => t.DetallesTicket)
                .HasForeignKey(dt => dt.TicketId);

            modelBuilder.Entity<DetalleTicket>()
                .HasRequired(dt => dt.Producto)
                .WithMany()
                .HasForeignKey(dt => dt.ProductoId);

            modelBuilder.Entity<Pago>()
                .HasRequired(p => p.Ticket)
                .WithMany(t => t.Pagos)
                .HasForeignKey(p => p.TicketId);

            base.OnModelCreating(modelBuilder);
        }
    }
}