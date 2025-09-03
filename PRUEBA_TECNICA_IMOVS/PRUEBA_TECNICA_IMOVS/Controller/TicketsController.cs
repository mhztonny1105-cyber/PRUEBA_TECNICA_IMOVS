using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Data;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controller
{
    [RoutePrefix("api/tickets")]
    public class TicketsController : ApiController
    {
        private readonly AppDbContext _db = new AppDbContext();
        private readonly TicketService _svc;

        public TicketsController()
        {
            _svc = new TicketService(_db);
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var data = _db.Tickets
                .Include(t => t.Detalles.Select(d => d.Producto))
                .Include(t => t.Pagos)
                .ToList()
                .Select(MapTicketToDto)
                .ToList();

            return Ok(ApiResponse<object>.Success(data));
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var t = _db.Tickets
                .Include(x => x.Detalles.Select(d => d.Producto))
                .Include(x => x.Pagos)
                .FirstOrDefault(x => x.Id == id);

            if (t == null) return Content(HttpStatusCode.NotFound, ApiResponse<object>.Fail("No encontrado"));
            return Ok(ApiResponse<object>.Success(MapTicketToDto(t)));
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create(TicketCreateDto dto)
        {
            if (dto == null || dto.Detalles == null || dto.Detalles.Count == 0)
                return BadRequest("Debe enviar al menos un detalle.");

            var ticket = new Ticket
            {
                Folio = string.IsNullOrWhiteSpace(dto.Folio) ? TicketService.GenerarFolioTicket() : dto.Folio.Trim(),
                FechaCreacion = DateTime.Now,
                Estatus = "Por pagar"
            };
            _db.Tickets.Add(ticket);
            _db.SaveChanges(); 

            foreach (var det in dto.Detalles)
            {
                var prod = _db.Productos.Find(det.ProductoId);
                if (prod == null) return BadRequest($"Producto {det.ProductoId} inexistente.");

                var td = new TicketDetalle
                {
                    TicketId = ticket.Id,
                    ProductoId = prod.Id,
                    Cantidad = det.Cantidad,
                    PrecioUnitario = prod.PrecioUnitario, 
                    Subtotal = prod.PrecioUnitario * det.Cantidad
                };
                _db.TicketDetalles.Add(td);
            }
            _db.SaveChanges();

            ticket.Total = _svc.CalcularTotal(ticket.Id);
            _db.SaveChanges();

            var dtoResp = MapTicketToDto(_db.Tickets
                .Include(t => t.Detalles.Select(d => d.Producto))
                .Include(t => t.Pagos)
                .First(t => t.Id == ticket.Id));

            return Created($"api/tickets/{ticket.Id}", ApiResponse<object>.Success(dtoResp, "Ticket creado"));
        }

        [HttpPut, Route("{id:int}")]
        public IHttpActionResult Update(int id, Ticket update)
        {
            var t = _db.Tickets.Find(id);
            if (t == null) return Content(HttpStatusCode.NotFound, ApiResponse<object>.Fail("No encontrado"));

            if (!string.IsNullOrWhiteSpace(update.Folio)) t.Folio = update.Folio.Trim();
            if (!string.IsNullOrWhiteSpace(update.Estatus)) t.Estatus = update.Estatus.Trim();
            _db.SaveChanges();

            var dtoResp = MapTicketToDto(_db.Tickets
                .Include(x => x.Detalles.Select(d => d.Producto))
                .Include(x => x.Pagos)
                .First(x => x.Id == id));

            return Ok(ApiResponse<object>.Success(dtoResp, "Ticket actualizado"));
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var t = _db.Tickets.Find(id);
            if (t == null) return Content(HttpStatusCode.NotFound, ApiResponse<object>.Fail("No encontrado"));
            _db.Tickets.Remove(t);
            _db.SaveChanges();
            return Ok(ApiResponse<object>.Success(null, "Eliminado"));
        }

        [HttpGet, Route("{id:int}/pagos")]
        public IHttpActionResult Pagos(int id)
        {
            var existe = _db.Tickets.Any(t => t.Id == id);
            if (!existe) return Content(HttpStatusCode.NotFound, ApiResponse<object>.Fail("Ticket no encontrado"));

            var pagos = _db.Pagos
                .Where(p => p.TicketId == id)
                .OrderByDescending(p => p.FechaPago)
                .ThenByDescending(p => p.NumeroPago)
                .ToList()
                .Select(p => new PagoDto
                {
                    Id = p.Id,
                    NumeroPago = p.NumeroPago,
                    Folio = p.Folio,
                    FechaPago = p.FechaPago,
                    Monto = p.Monto
                }).ToList();

            return Ok(ApiResponse<object>.Success(pagos));
        }

        private TicketDto MapTicketToDto(Ticket t)
        {
            var pagado = t.Pagos?.Sum(x => x.Monto) ?? 0m;
            var pendiente = Math.Max(0, t.Total - pagado);

            return new TicketDto
            {
                Id = t.Id,
                Folio = t.Folio,
                FechaCreacion = t.FechaCreacion,
                FechaLiquidacion = t.FechaLiquidacion,
                Estatus = t.Estatus,
                Total = t.Total,
                Pagado = pagado,
                Pendiente = pendiente,
                Detalles = t.Detalles?.Select(d => new TicketDetalleDto
                {
                    Id = d.Id,
                    ProductoId = d.ProductoId,
                    Producto = d.Producto?.Nombre,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    Subtotal = d.Subtotal
                }).ToList(),
                Pagos = t.Pagos?.OrderByDescending(p => p.FechaPago)
                    .ThenByDescending(p => p.NumeroPago)
                    .Select(p => new PagoDto
                    {
                        Id = p.Id,
                        NumeroPago = p.NumeroPago,
                        Folio = p.Folio,
                        FechaPago = p.FechaPago,
                        Monto = p.Monto
                    }).ToList()
            };
        }
    }
}