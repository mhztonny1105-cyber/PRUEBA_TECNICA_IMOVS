using System;
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
        public virtual DbSet<Cotizacion> Cotizaciones { get; set; }
        public virtual DbSet<CotizacionDetalle> CotizacionDetalles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CotizacionDetalle>()
                .HasRequired(cd => cd.Cotizacion)
                .WithMany(c => c.Detalles)
                .HasForeignKey(cd => cd.CotizacionId)
                .WillCascadeOnDelete(false); 

            modelBuilder.Entity<CotizacionDetalle>()
                .HasRequired(cd => cd.Producto)
                .WithMany()
                .HasForeignKey(cd => cd.ProductoId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}