using System;


namespace PRUEBA_TECNICA_IMOVS.Api
{
    public static class FolioGenerator
    {
        public static string GenerateTicketFolio()
        {
            // Formato legible y único (fecha + micro ticks)
            return $"T-{DateTime.UtcNow:yyyyMMdd}-{DateTime.UtcNow.Ticks % 1000000:D6}";
        }


        public static string GeneratePaymentFolio(string ticketFolio, int paymentNumber)
        {
            return $"P-{ticketFolio}-{paymentNumber:D3}";
        }
    }
}