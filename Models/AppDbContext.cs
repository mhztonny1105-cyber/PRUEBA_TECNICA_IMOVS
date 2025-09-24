using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DefaultConnection") { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketDetalle> TicketDetalles { get; set; }
        public DbSet<Pago> Pagos { get; set; }
    }
}