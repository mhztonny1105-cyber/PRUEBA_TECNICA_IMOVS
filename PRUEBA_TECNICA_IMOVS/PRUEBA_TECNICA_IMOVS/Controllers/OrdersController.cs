using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Routing;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class OrdersController : ApiController
    {
        private Context db = new Context();
        private List<OrderItem> cart = new List<OrderItem>();

        // GET: api/Orders
        public IEnumerable<Order> GetOrders()
        {
            return db.Orders.Include(o => o.Items.Select(i => i.ProductId)).ToList();
        }

        // GET: api/Orders/5
        public IHttpActionResult GetOrder(int id)
        {
            var order = db.Orders
                .Include(o => o.Items.Select(i => i.ProductId))
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // POST: api/Orders
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validar y asociar productos a los OrderItems
            if (order.Items != null)
            {
                foreach (var item in order.Items)
                {
                    var product = db.Products.FirstOrDefault(p => p.Id == item.ProductId.Id);
                    if (product == null)
                        return BadRequest($"Producto con Id {item.ProductId.Id} no existe.");

                    if (item.Quantity <= 0)
                        return BadRequest("La cantidad debe ser mayor a cero.");

                    item.ProductId = product;
                    item.UnitPrice = product.Price;
                }
            }

            db.Orders.Add(order);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        // PUT: api/Orders/5
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != order.Id)
                return BadRequest();

            // Validar y asociar productos a los OrderItems
            if (order.Items != null)
            {
                foreach (var item in order.Items)
                {
                    var product = db.Products.FirstOrDefault(p => p.Id == item.ProductId.Id);
                    if (product == null)
                        return BadRequest($"Producto con Id {item.ProductId.Id} no existe.");

                    if (item.Quantity <= 0)
                        return BadRequest("La cantidad debe ser mayor a cero.");

                    item.ProductId = product;
                    item.UnitPrice = product.Price;
                }
            }

            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Orders/5
        public IHttpActionResult DeleteOrder(int id)
        {
            var order = db.Orders.Include(o => o.Items).FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            // Eliminar los OrderItems asociados primero si es necesario
            if (order.Items != null)
            {
                db.OrderItems.RemoveRange(order.Items);
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}