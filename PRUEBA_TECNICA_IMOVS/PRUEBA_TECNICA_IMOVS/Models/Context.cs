using System.Data.Entity;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public partial class Context : DbContext
    {
        public Context() : base("name=Context") {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketItem> TicketItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketItem>()
                .HasRequired(ti => ti.Ticket)
                .WithMany(t => t.Items)
                .HasForeignKey(ti => ti.TicketId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TicketItem>()
                .HasRequired(ti => ti.Product)
                .WithMany()
                .HasForeignKey(ti => ti.ProductId)
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
