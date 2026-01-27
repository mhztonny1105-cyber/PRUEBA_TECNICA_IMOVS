using PRUEBA_TECNICA_IMOVS.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Details)
                .WithRequired(d => d.Ticket)
                .HasForeignKey(d => d.TicketId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Payments)
                .WithRequired(p => p.Ticket)
                .HasForeignKey(p => p.TicketId)
                .WillCascadeOnDelete(true);
           
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketDetail> TicketDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
