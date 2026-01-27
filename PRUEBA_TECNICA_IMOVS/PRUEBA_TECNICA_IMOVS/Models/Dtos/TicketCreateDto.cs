using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.DTOs
{
    public class TicketCreateDto
    {
        [Required]
        public List<TicketDetailCreateDto> Details { get; set; }
    }
}
