using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.Models; // Asegúrate de que esta línea esté presente

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        // Propiedades DbSet para tus nuevas tablas
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<DetalleTicket> DetalleTickets { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
