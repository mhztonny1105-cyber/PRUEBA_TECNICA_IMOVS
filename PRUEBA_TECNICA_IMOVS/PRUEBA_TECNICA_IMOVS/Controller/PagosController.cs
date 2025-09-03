using System.Linq;
using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Data;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controller
{
    [RoutePrefix("api/pagos")]
    public class PagosController : ApiController
    {
        private readonly AppDbContext _db = new AppDbContext();
        private readonly TicketService _svc;

        public PagosController()
        {
            _svc = new TicketService(_db);
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var data = _db.Pagos
                .OrderByDescending(p => p.FechaPago)
                .ThenByDescending(p => p.NumeroPago)
                .ToList();
            return Ok(ApiResponse<object>.Success(data));
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var p = _db.Pagos.Find(id);
            if (p == null) return Content(HttpStatusCode.NotFound, ApiResponse<object>.Fail("No encontrado"));
            return Ok(ApiResponse<object>.Success(p));
        }

        [HttpPost, Route("")]
        public IHttpActionResult Registrar(RegistrarPagoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest("Modelo inválido");
            try
            {
                var pago = _svc.RegistrarPago(dto.TicketId, dto.Monto, dto.Folio);
                var pendiente = _svc.Pendiente(dto.TicketId);
                return Ok(ApiResponse<object>.Success(new
                {
                    Pago = new { pago.Id, pago.NumeroPago, pago.Folio, pago.FechaPago, pago.Monto },
                    Pendiente = pendiente
                }, "Pago registrado"));
            }
            catch (System.InvalidOperationException ex)
            {
                return Content(HttpStatusCode.BadRequest, ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var p = _db.Pagos.Find(id);
            if (p == null) return Content(HttpStatusCode.NotFound, ApiResponse<object>.Fail("No encontrado"));
            _db.Pagos.Remove(p);
            _db.SaveChanges();
            return Ok(ApiResponse<object>.Success(null, "Eliminado"));
        }
    }
}