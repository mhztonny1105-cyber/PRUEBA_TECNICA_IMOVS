using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("EstatusTickets")]
    public class EstatusTicket
    {
        [Key]
        public long EstatusTicketId { get; set; }

        [Required]
        [StringLength(20)]
        public string Clave { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
    }
}
