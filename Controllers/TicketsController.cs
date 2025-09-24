using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using PRUEBA_TECNICA_IMOVS.Models;

public class TicketsController : ApiController
{
    private readonly AppDbContext _context = new AppDbContext();

    // GET: api/tickets
    [HttpGet]
    public IHttpActionResult Get()
    {
        var tickets = _context.Tickets
            .Include(t => t.Detalles)
            .Include(t => t.Pagos)
            .ToList();

        return Ok(tickets);
    }

    // GET: api/tickets/5
    [HttpGet]
    public IHttpActionResult Get(int id)
    {
        var ticket = _context.Tickets
            .Include(t => t.Detalles.Select(d => d.Producto))
            .Include(t => t.Pagos)
            .FirstOrDefault(t => t.Id == id);

        if (ticket == null)
            return NotFound();

        return Ok(ticket);
    }

    // POST: api/tickets
    [HttpPost]
    public IHttpActionResult Post(Ticket ticket)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Calcular totales
        decimal total = 0;
        foreach (var detalle in ticket.Detalles)
        {
            var producto = _context.Productos.Find(detalle.ProductoId);
            if (producto == null)
                return BadRequest($"Producto con Id {detalle.ProductoId} no existe.");

            detalle.PrecioUnitario = producto.PrecioUnitario;
            detalle.Subtotal = detalle.Cantidad * producto.PrecioUnitario;
            total += detalle.Subtotal;
        }

        ticket.Total = total;
        ticket.Pendiente = total;
        ticket.FechaCreacion = DateTime.Now;
        ticket.Estatus = "Por pagar";
        ticket.Folio = $"T-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";

        _context.Tickets.Add(ticket);
        _context.SaveChanges();

        return Ok(ticket);
    }

    // PUT: api/tickets/5
    [HttpPut]
    public IHttpActionResult Put(int id, Ticket ticket)
    {
        var existing = _context.Tickets.Find(id);
        if (existing == null)
            return NotFound();

        existing.FechaLiquidacion = ticket.FechaLiquidacion;
        existing.Estatus = ticket.Estatus;
        _context.SaveChanges();

        return Ok(existing);
    }

    // DELETE: api/tickets/5
    [HttpDelete]
    public IHttpActionResult Delete(int id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null)
            return NotFound();

        _context.Tickets.Remove(ticket);
        _context.SaveChanges();

        return Ok();
    }
}
