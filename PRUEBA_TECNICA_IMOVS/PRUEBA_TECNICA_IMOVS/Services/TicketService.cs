using System;
using System.Collections.Generic;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Repositories;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<Producto> _productoRepository;
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IRepository<Pago> _pagoRepository;
        private readonly IRepository<EstatusTicket> _estatusTicketRepository;

        public TicketService()
        {
            var dbContext = new Context();
            _ticketRepository = new Repository<Ticket>(dbContext);
            _productoRepository = new Repository<Producto>(dbContext);
            _usuarioRepository = new Repository<Usuario>(dbContext);
            _pagoRepository = new Repository<Pago>(dbContext);
            _estatusTicketRepository = new Repository<EstatusTicket>(dbContext);
        }

        public TicketService(
            IRepository<Ticket> ticketRepository,
            IRepository<Producto> productoRepository,
            IRepository<Usuario> usuarioRepository,
            IRepository<Pago> pagoRepository,
            IRepository<EstatusTicket> estatusTicketRepository)
        {
            _ticketRepository = ticketRepository;
            _productoRepository = productoRepository;
            _usuarioRepository = usuarioRepository;
            _pagoRepository = pagoRepository;
            _estatusTicketRepository = estatusTicketRepository;
        }

        public TicketDto CrearTicket(CrearTicketDto ticketDataTransferObject)
        {
            var ticket = new Ticket
            {
                FolioTicket = "TK-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                CreadoPor = ticketDataTransferObject.UsuarioId,
                FechaCreacion = DateTime.Now,
                MontoPagado = 0,
                EstatusTicketId = 1
            };

            decimal total = 0;
            foreach (var item in ticketDataTransferObject.Detalles)
            {
                var producto = _productoRepository.GetById(item.ProductoId);
                if (producto != null)
                {
                    var detalle = new TicketDetalle
                    {
                        ProductoId = item.ProductoId,
                        Cantidad = item.Cantidad,
                        PrecioUnitario = producto.PrecioUnitario,
                        TotalFila = item.Cantidad * producto.PrecioUnitario
                    };
                    ticket.Detalles.Add(detalle);
                    total += detalle.TotalFila;
                }
            }

            ticket.TotalTicket = total;
            ticket.MontoPendiente = total;

            _ticketRepository.Add(ticket);
            _ticketRepository.Save();

            return MapToDto(ticket);
        }

        public TicketDto GetTicketById(long id)
        {
            var ticket = _ticketRepository.GetById(id);
            return ticket != null ? MapToDto(ticket) : null;
        }

        public IEnumerable<TicketDto> GetAllTickets()
        {
            return _ticketRepository.GetAll().Select(ticket => MapToDto(ticket)).ToList();
        }

        public PagoDto RegistrarPago(RegistrarPagoDto pagoDataTransferObject)
        {
            var ticket = _ticketRepository.GetById(pagoDataTransferObject.TicketId);
            if (ticket == null || ticket.MontoPendiente <= 0) return null;

            var numeroPago = ticket.Pagos.Count + 1;
            var pago = new Pago
            {
                TicketId = pagoDataTransferObject.TicketId,
                UsuarioId = pagoDataTransferObject.UsuarioId,
                FolioPago = "PG-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                NumeroPago = numeroPago,
                MontoPago = pagoDataTransferObject.MontoPago,
                FechaPago = DateTime.Now
            };

            ticket.MontoPagado += pagoDataTransferObject.MontoPago;
            ticket.MontoPendiente = ticket.TotalTicket - ticket.MontoPagado;

            if (ticket.MontoPendiente <= 0)
            {
                ticket.MontoPendiente = 0;
                ticket.EstatusTicketId = 2;
                ticket.FechaLiquidacion = DateTime.Now;
            }

            _pagoRepository.Add(pago);
            _ticketRepository.Update(ticket);
            _pagoRepository.Save();

            return new PagoDto
            {
                FolioPago = pago.FolioPago,
                NumeroPago = pago.NumeroPago,
                MontoPago = pago.MontoPago,
                FechaPago = pago.FechaPago,
                Usuario = _usuarioRepository.GetById(pago.UsuarioId)?.Nombre
            };
        }

        public IEnumerable<PagoDto> GetHistorialPagos(long ticketId)
        {
            return _pagoRepository.Find(pago => pago.TicketId == ticketId)
                .OrderByDescending(pago => pago.FechaPago)
                .Select(pago => new PagoDto
                {
                    FolioPago = pago.FolioPago,
                    NumeroPago = pago.NumeroPago,
                    MontoPago = pago.MontoPago,
                    FechaPago = pago.FechaPago,
                    Usuario = pago.Usuario?.Nombre
                }).ToList();
        }

        private TicketDto MapToDto(Ticket ticket)
        {
            return new TicketDto
            {
                TicketId = ticket.TicketId,
                FolioTicket = ticket.FolioTicket,
                FechaCreacion = ticket.FechaCreacion,
                FechaLiquidacion = ticket.FechaLiquidacion,
                TotalTicket = ticket.TotalTicket,
                MontoPagado = ticket.MontoPagado,
                MontoPendiente = ticket.MontoPendiente,
                Estatus = ticket.EstatusTicket?.Descripcion,
                Detalles = ticket.Detalles.Select(detalle => new TicketDetalleDto
                {
                    Producto = detalle.Producto?.Nombre,
                    Cantidad = detalle.Cantidad,
                    PrecioUnitario = detalle.PrecioUnitario,
                    TotalFila = detalle.TotalFila
                }).ToList()
            };
        }
    }
}
