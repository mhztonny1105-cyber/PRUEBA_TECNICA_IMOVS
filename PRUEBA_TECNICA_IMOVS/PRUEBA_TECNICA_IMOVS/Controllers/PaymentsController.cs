using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class PaymentsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Payments
        public IEnumerable<Payments> GetPayments()
        {
            return db.Set<Payments>().Include(p => p.OrderId).ToList();
        }

        // GET: api/Payments/5
        public IHttpActionResult GetPayment(int id)
        {
            var payment = db.Set<Payments>().Include(p => p.OrderId).FirstOrDefault(p => p.Id == id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        // POST: api/Payments
        public IHttpActionResult PostPayment(Payments payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = db.Set<Order>().FirstOrDefault(o => o.Id == payment.OrderId.Id);
            if (order == null)
                return BadRequest("La orden asociada no existe.");

            if (order.PaysRemaining == 0) return BadRequest("La orden ya ha sido pagada en su totalidad.");

            payment.OrderId = order;
            payment.PaymentNumber = order.PaysQuantity - order.PaysRemaining + 1;
            payment.RemainingAmount = order.TotalAmount - (payment.PaymentNumber * (order.TotalAmount / order.PaysQuantity));
            payment.Amount = order.TotalAmount / order.PaysQuantity;
            order.PaysRemaining -= 1;
            order.Status = order.PaysRemaining == 0 ? "Paid" : "Pending";
            db.Payments.Add(payment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = payment.Id }, payment);
        }

        // PUT: api/Payments/5
        public IHttpActionResult PutPayment(int id, Payments payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != payment.Id)
                return BadRequest();

            var order = db.Set<Order>().FirstOrDefault(o => o.Id == payment.OrderId.Id);
            if (order == null)
                return BadRequest("La orden asociada no existe.");

            payment.OrderId = order;

            db.Entry(payment).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Payments/5
        public IHttpActionResult DeletePayment(int id)
        {
            var payment = db.Set<Payments>().Find(id);
            if (payment == null)
                return NotFound();

            db.Set<Payments>().Remove(payment);
            db.SaveChanges();

            return Ok(payment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}