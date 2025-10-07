using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using departamental.Models;

namespace departamental.Services
{
    public class ProductoService
    {
        private readonly ContextoDepa _context = new ContextoDepa();

        public Respuesta<IEnumerable<Producto>> ListarProductos()
        {
            var respuesta = new Respuesta<IEnumerable<Producto>>();
            try
            {
                respuesta.Datos = _context.Productos.ToList();
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }
        public Respuesta<Producto> CrearProducto(Producto p)
        {
            var respuesta = new Respuesta<Producto>();
            try
            {
                _context.Productos.Add(p);
                _context.SaveChanges();
                respuesta.Datos = p;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}