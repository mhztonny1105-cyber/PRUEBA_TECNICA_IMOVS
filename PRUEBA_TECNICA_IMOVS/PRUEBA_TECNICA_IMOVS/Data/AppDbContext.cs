using System.Data.Entity;
using PRUEBA_TECNICA_IMOVS.Api.Models.Entities;


namespace PRUEBA_TECNICA_IMOVS.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("CompanyDb") { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketLine> TicketLines { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Precisión para decimales
            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(18, 2));


            // Relaciones
            modelBuilder.Entity<TicketLine>()
            .HasRequired(tl => tl.Ticket)
            .WithMany(t => t.Lines)
            .HasForeignKey(tl => tl.TicketId)
            .WillCascadeOnDelete(true);


            modelBuilder.Entity<TicketLine>()
            .HasRequired(tl => tl.Product)
            .WithMany()
            .HasForeignKey(tl => tl.ProductId)
            .WillCascadeOnDelete(false);


            modelBuilder.Entity<Payment>()
            .HasRequired(p => p.Ticket)
            .WithMany(t => t.Payments)
            .HasForeignKey(p => p.TicketId)
            .WillCascadeOnDelete(true);


            base.OnModelCreating(modelBuilder);
        }
    }
}