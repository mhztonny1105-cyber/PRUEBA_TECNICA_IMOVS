using System.Data.Entity;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Models {
    public class Context : DbContext {
        public Context() : base("DefaultConnection") {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketDetalle> TicketDetalles { get; set; }
        public DbSet<Pago> Pagos { get; set; }
    }
}
