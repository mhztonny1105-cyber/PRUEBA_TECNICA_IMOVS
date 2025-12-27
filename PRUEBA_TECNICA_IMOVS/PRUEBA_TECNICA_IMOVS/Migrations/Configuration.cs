namespace PRUEBA_TECNICA_IMOVS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using PRUEBA_TECNICA_IMOVS.Models.Entities;

    public sealed class Configuration : DbMigrationsConfiguration<PRUEBA_TECNICA_IMOVS.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PRUEBA_TECNICA_IMOVS.Models.Context context)
        {
            context.EstatusTickets.AddOrUpdate(e => e.Clave,
                new EstatusTicket { Clave = "PENDIENTE", Descripcion = "Por pagar" },
                new EstatusTicket { Clave = "PAGADO", Descripcion = "Pagado" }
            );

            context.Usuarios.AddOrUpdate(u => u.Username,
                new Usuario { 
                    Nombre = "Administrador Sistema", 
                    Username = "admin", 
                    Rol = "Admin", 
                    Estatus = "ACTIVO", 
                    FechaCreacion = DateTime.Now 
                }
            );

            context.Productos.AddOrUpdate(p => p.Nombre,
                new Producto { 
                    Nombre = "Laptop Pro", 
                    Descripcion = "Laptop de alto rendimiento", 
                    PrecioUnitario = 1500.00m, 
                    Estatus = "ACTIVO", 
                    FechaCreacion = DateTime.Now 
                },
                new Producto { 
                    Nombre = "Mouse Óptico", 
                    Descripcion = "Mouse ergonómico", 
                    PrecioUnitario = 25.00m, 
                    Estatus = "ACTIVO", 
                    FechaCreacion = DateTime.Now 
                },
                new Producto { 
                    Nombre = "Teclado Mecánico", 
                    Descripcion = "Teclado con switches cherry blue", 
                    PrecioUnitario = 85.00m, 
                    Estatus = "ACTIVO", 
                    FechaCreacion = DateTime.Now 
                }
            );
        }
    }
}
