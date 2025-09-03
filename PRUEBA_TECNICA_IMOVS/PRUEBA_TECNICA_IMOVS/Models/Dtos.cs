using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class TicketDetalleCreateDto
    {
        [Required] public int ProductoId { get; set; }
        [Range(1, 999999)] public int Cantidad { get; set; }
    }

    public class TicketCreateDto
    {
        [Required] public List<TicketDetalleCreateDto> Detalles { get; set; }
        public string Folio { get; set; }
    }

    public class TicketDetalleDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
    
    public class PagoDto
    {
        public int Id { get; set; }
        public int NumeroPago { get; set; }
        public string Folio { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
    }

    public class TicketDto
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        public string Estatus { get; set; }
        public decimal Total { get; set; }
        public decimal Pagado { get; set; }
        public decimal Pendiente { get; set; }
        public List<TicketDetalleDto> Detalles { get; set; }
        public List<PagoDto> Pagos { get; set; }
    }

    public class RegistrarPagoDto
    {
        [Required] public int TicketId { get; set; }
        [Range(0.01, 999999)] public decimal Monto { get; set; }
        public string Folio { get; set; } // opcional
    }
}