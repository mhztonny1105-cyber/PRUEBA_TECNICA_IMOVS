using System;

namespace PRUEBA_TECNICA_IMOVS.Models.DTOs
{
    public class PagoDto
    {
        public string FolioPago { get; set; }
        public int NumeroPago { get; set; }
        public decimal MontoPago { get; set; }
        public DateTime FechaPago { get; set; }
        public string Usuario { get; set; }
    }
}
