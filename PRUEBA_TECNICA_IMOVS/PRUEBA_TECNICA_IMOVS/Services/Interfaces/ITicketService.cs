using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA_TECNICA_IMOVS.Services.Interfaces
{
    public interface ITicketService
    {
        Ticket Create(TicketCreateDto dto);
        Ticket GetById(Guid id);
        IEnumerable<Ticket> GetAll();
    }
}
