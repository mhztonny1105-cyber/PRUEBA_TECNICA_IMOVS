using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
	[RoutePrefix("api/tickets")]
	public class TicketsController : ApiController
	{
		private PagosContext db = new PagosContext();

		// GET: api/tickets
		[HttpGet]
		[Route("")]
		public async Task<IHttpActionResult> GetTickets()
		{
			try
			{
				var tickets = await db.Tickets
					.Include(t => t.DetallesTicket.Select(dt => dt.Producto))
					.Include(t => t.Pagos)
					.OrderByDescending(t => t.FechaCreacion)
					.Select(t => new
					{
						t.Id,
						t.Folio,
						t.Cliente,
						t.MontoTotal,
						t.MontoPagado,
						MontoPendiente = t.MontoTotal - t.MontoPagado,
						t.Estatus,
						t.FechaCreacion,
						t.FechaLiquidacion,
						TotalProductos = t.DetallesTicket.Count,
						TotalPagos = t.Pagos.Count
					})
					.ToListAsync();

				return Ok(ApiResponse<object>.SuccessResponse(tickets, "Tickets obtenidos exitosamente"));
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		// GET: api/tickets/5
		[HttpGet]
		[Route("{id:int}")]
		public async Task<IHttpActionResult> GetTicket(int id)
		{
			try
			{
				var ticket = await db.Tickets
					.Include(t => t.DetallesTicket.Select(dt => dt.Producto))
					.Include(t => t.Pagos)
					.Where(t => t.Id == id)
					.Select(t => new
					{
						t.Id,
						t.Folio,
						t.Cliente,
						t.MontoTotal,
						t.MontoPagado,
						MontoPendiente = t.MontoTotal - t.MontoPagado,
						t.Estatus,
						t.FechaCreacion,
						t.FechaLiquidacion,
						Detalles = t.DetallesTicket.Select(dt => new
						{
							dt.Id,
							dt.ProductoId,
							NombreProducto = dt.Producto.Nombre,
							dt.Cantidad,
							dt.PrecioUnitario,
							PrecioTotal = dt.Cantidad * dt.PrecioUnitario
						}),
						Pagos = t.Pagos.OrderByDescending(p => p.FechaPago).Select(p => new
						{
							p.Id,
							p.Folio,
							p.NumeroPago,
							p.Monto,
							p.FechaPago,
							p.Comentarios
						})
					})
					.FirstOrDefaultAsync();

				if (ticket == null)
				{
					return NotFound();
				}

				return Ok(ApiResponse<object>.SuccessResponse(ticket, "Ticket encontrado"));
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		// POST: api/tickets
		[HttpPost]
		[Route("")]
		public async Task<IHttpActionResult> PostTicket(TicketCreateDto ticketDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				// Validaciones
				if (ticketDto.DetallesTicket == null || !ticketDto.DetallesTicket.Any())
				{
					return BadRequest("El ticket debe tener al menos un producto");
				}

				// Generar folio único
				string folio = GenerarFolio();

				// Crear ticket
				var ticket = new Ticket
				{
					Folio = folio,
					Cliente = ticketDto.Cliente,
					FechaCreacion = DateTime.Now,
					Estatus = "Por Pagar"
				};

				decimal montoTotal = 0;

				// Agregar detalles
				foreach (var detalleDto in ticketDto.DetallesTicket)
				{
					// Validar que el producto existe
					var producto = await db.Productos.FindAsync(detalleDto.ProductoId);
					if (producto == null || !producto.Activo)
					{
						return BadRequest($"El producto con ID {detalleDto.ProductoId} no existe o no está activo");
					}

					// Validar stock
					if (producto.Stock < detalleDto.Cantidad)
					{
						return BadRequest($"Stock insuficiente para el producto {producto.Nombre}. Stock disponible: {producto.Stock}");
					}

					var detalle = new DetalleTicket
					{
						ProductoId = detalleDto.ProductoId,
						Cantidad = detalleDto.Cantidad,
						PrecioUnitario = producto.PrecioUnitario
					};

					ticket.DetallesTicket.Add(detalle);
					montoTotal += detalle.PrecioTotal;

					// Actualizar stock
					producto.Stock -= detalleDto.Cantidad;
				}

				ticket.MontoTotal = montoTotal;

				db.Tickets.Add(ticket);
				await db.SaveChangesAsync();

				return Ok(ApiResponse<object>.SuccessResponse(new { ticket.Id, ticket.Folio, ticket.MontoTotal }, "Ticket creado exitosamente"));
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		// PUT: api/tickets/5
		[HttpPut]
		[Route("{id:int}")]
		public async Task<IHttpActionResult> PutTicket(int id, TicketUpdateDto ticketDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var ticket = await db.Tickets.FindAsync(id);
				if (ticket == null)
				{
					return NotFound();
				}

				// Solo permitir editar si no tiene pagos
				var tienePagos = await db.Pagos.AnyAsync(p => p.TicketId == id);
				if (tienePagos)
				{
					return BadRequest("No se puede modificar un ticket que ya tiene pagos registrados");
				}

				// Actualizar solo cliente (ejemplo de campos editables)
				ticket.Cliente = ticketDto.Cliente;

				await db.SaveChangesAsync();

				return Ok(ApiResponse<object>.SuccessResponse(ticket, "Ticket actualizado exitosamente"));
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		// DELETE: api/tickets/5
		[HttpDelete]
		[Route("{id:int}")]
		public async Task<IHttpActionResult> DeleteTicket(int id)
		{
			try
			{
				var ticket = await db.Tickets
					.Include(t => t.DetallesTicket.Select(dt => dt.Producto))
					.Include(t => t.Pagos)
					.FirstOrDefaultAsync(t => t.Id == id);

				if (ticket == null)
				{
					return NotFound();
				}

				// No permitir eliminar si tiene pagos
				if (ticket.Pagos.Any())
				{
					return BadRequest("No se puede eliminar un ticket que tiene pagos registrados");
				}

				// Restaurar stock de productos
				foreach (var detalle in ticket.DetallesTicket)
				{
					detalle.Producto.Stock += detalle.Cantidad;
				}

				// Eliminar detalles primero
				db.DetallesTicket.RemoveRange(ticket.DetallesTicket);

				// Eliminar ticket
				db.Tickets.Remove(ticket);

				await db.SaveChangesAsync();

				return Ok(ApiResponse<object>.SuccessResponse(null, "Ticket eliminado exitosamente"));
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		private string GenerarFolio()
		{
			return "TKT-" + DateTime.Now.ToString("yyyyMMdd") + "-" + new Random().Next(1000, 9999);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}

	// DTOs para crear y actualizar tickets
	public class TicketCreateDto
	{
		public string Cliente { get; set; }
		public DetalleTicketDto[] DetallesTicket { get; set; }
	}

	public class TicketUpdateDto
	{
		public string Cliente { get; set; }
	}

	public class DetalleTicketDto
	{
		public int ProductoId { get; set; }
		public int Cantidad { get; set; }
	}
}