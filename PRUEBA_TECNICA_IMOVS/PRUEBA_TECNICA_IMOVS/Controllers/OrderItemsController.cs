using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class OrderItemsController : ApiController
    {
        private Context db = new Context();

        // GET: api/OrderItems
        public IEnumerable<OrderItem> GetOrderItems()
        {
            return db.Set<OrderItem>().Include(o => o.ProductId).ToList();
        }

        // GET: api/OrderItems/5
        public IHttpActionResult GetOrderItem(int id)
        {
            var orderItem = db.Set<OrderItem>().Include(o => o.ProductId).FirstOrDefault(o => o.Id == id);
            if (orderItem == null)
                return NotFound();

            return Ok(orderItem);
        }

        // POST: api/OrderItems
        public IHttpActionResult PostOrderItem(OrderItem orderItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Products product = db.Set<Products>().FirstOrDefault(p => p.Id == orderItem.ProductId.Id);

            if (product == null) return NotFound();

            if (orderItem.Quantity <= 0) return BadRequest("Quantity must be greater than zero.");

            orderItem.ProductId = product;
            orderItem.UnitPrice = product.Price;

            db.Set<OrderItem>().Add(orderItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderItem.Id }, orderItem);
        }

        // PUT: api/OrderItems/5
        public IHttpActionResult PutOrderItem(int id, OrderItem orderItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != orderItem.Id)
                return BadRequest();

            Products product = db.Set<Products>().FirstOrDefault(p => p.Id == orderItem.ProductId.Id);

            if (product == null) return NotFound();

            if (orderItem.Quantity <= 0) return BadRequest("Quantity must be greater than zero.");

            orderItem.ProductId = product;
            orderItem.UnitPrice = product.Price;


            db.Entry(orderItem).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/OrderItems/5
        public IHttpActionResult DeleteOrderItem(int id)
        {
            var orderItem = db.Set<OrderItem>().Find(id);
            if (orderItem == null)
                return NotFound();

            db.Set<OrderItem>().Remove(orderItem);
            db.SaveChanges();

            return Ok(orderItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}