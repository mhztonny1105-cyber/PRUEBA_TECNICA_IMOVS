using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.DTOs
{
    public class CreateTicketDto
    {
        [Required]
        public string Folio { get; set; }

        [Required]
        public List<CreateTicketDetailDto> Details { get; set; }
    }

    public class CreateTicketDetailDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
