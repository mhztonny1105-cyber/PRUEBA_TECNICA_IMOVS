using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class ProductosController : ApiController
    {
        // Instancia de tu contexto de base de datos
        private Context db = new Context();

        // GET: api/Productos
        public IHttpActionResult GetProductos()
        {
            var productos = db.Productos.ToList();
            return Ok(productos);
        }

        // GET: api/Productos/1
        public IHttpActionResult GetProducto(int id)
        {
            var producto = db.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public IHttpActionResult PostProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Productos.Add(producto);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = producto.Id }, producto);
        }

        [HttpPut]
        public IHttpActionResult PutProducto(int id, Producto producto)
        {
            if (!ModelState.IsValid || id != producto.Id)
            {
                return BadRequest(ModelState);
            }

            db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteProducto(int id)
        {
            var producto = db.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            db.Productos.Remove(producto);
            db.SaveChanges();

            return Ok(producto);
        }


        // Aquí es donde deberás agregar los otros métodos (POST, PUT, DELETE)
    }
}