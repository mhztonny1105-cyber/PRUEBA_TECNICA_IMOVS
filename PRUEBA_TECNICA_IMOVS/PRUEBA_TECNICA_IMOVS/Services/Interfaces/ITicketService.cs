using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using System;
using System.Collections.Generic;

namespace PRUEBA_TECNICA_IMOVS.Services.Interfaces
{
    public interface ITicketService
    {
        TicketResponseDto Create(TicketCreateDto dto);
        TicketResponseDto GetById(Guid id);
        IEnumerable<TicketResponseDto> GetAll();
    }
}
