using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace departamental.Models
{
    public class ContextoDepa : DbContext
    {
        public ContextoDepa() : base("ContextoDepa") { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<DetalleTicket> DetalleTickets { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties<decimal>().Configure(p => p.HasPrecision(10, 2));
        }



    }
}