using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public long UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Rol { get; set; }

        [Required]
        [StringLength(20)]
        public string Estatus { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Ticket> TicketsCreados { get; set; } = new List<Ticket>();
        public virtual ICollection<Pago> PagosRegistrados { get; set; } = new List<Pago>();
    }
}
