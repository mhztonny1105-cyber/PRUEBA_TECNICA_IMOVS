using PRUEBA_TECNICA_IMOVS.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

public class PagosController : ApiController
{
    private readonly AppDbContext _context = new AppDbContext();

    // GET: api/pagos/ticket/5
    [HttpGet]
    [Route("api/pagos/ticket/{ticketId}")]
    public IHttpActionResult GetPagosPorTicket(int ticketId)
    {
        var pagos = _context.Pagos
            .Where(p => p.TicketId == ticketId)
            .OrderByDescending(p => p.FechaPago)
            .Select(p => new
            {
                p.Id,
                p.NumeroPago,
                p.Folio,
                p.Monto,
                p.FechaPago,
                p.TicketId
            })
            .ToList();

        if (!pagos.Any())
            return NotFound();

        return Ok(pagos);
    }

    // GET: api/pagos/5
    [HttpGet]
    public IHttpActionResult Get(int id)
    {
        var pago = _context.Pagos
            .Where(p => p.Id == id)
            .Select(p => new
            {
                p.Id,
                p.NumeroPago,
                p.Folio,
                p.Monto,
                p.FechaPago,
                p.TicketId
            })
            .FirstOrDefault();

        if (pago == null)
            return NotFound();

        return Ok(pago);
    }

    // POST: api/pagos
    [HttpPost]
    public IHttpActionResult Post(Pago pago)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var ticket = _context.Tickets
            .Include(t => t.Pagos)
            .FirstOrDefault(t => t.Id == pago.TicketId);

        if (ticket == null)
            return BadRequest("El ticket no existe.");

        // Número de pago incremental
        pago.NumeroPago = ticket.Pagos.Count + 1;
        pago.Folio = $"P-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
        pago.FechaPago = DateTime.Now;

        _context.Pagos.Add(pago);

        // Actualizar pendiente
        ticket.Pendiente -= pago.Monto;
        if (ticket.Pendiente <= 0)
        {
            ticket.Pendiente = 0;
            ticket.Estatus = "Pagado";
            ticket.FechaLiquidacion = DateTime.Now;
        }

        _context.SaveChanges();

        // 🔥 Devolver solo propiedades planas para evitar error de serialización
        return Ok(new
        {
            pago.Id,
            pago.NumeroPago,
            pago.Folio,
            pago.Monto,
            pago.FechaPago,
            pago.TicketId
        });
    }

    // DELETE: api/pagos/5
    [HttpDelete]
    public IHttpActionResult Delete(int id)
    {
        var pago = _context.Pagos.Find(id);
        if (pago == null)
            return NotFound();

        _context.Pagos.Remove(pago);
        _context.SaveChanges();

        return Ok(new { message = "Pago eliminado correctamente" });
    }
}
