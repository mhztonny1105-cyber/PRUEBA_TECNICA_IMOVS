using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Repositories.Interfaces;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public class TicketService: ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }

        public Ticket GetAll()
        {
            var products = _repository.GetAll();
            return products;
        }

        public Ticket GetById(int id)
        {
            var product = _repository.GetById(id);
            return product;
        }

        public Ticket Create(CreateTicketDto createTicketDto)
        {
            var product = _repository.Create(createTicketDto);
            return product;
        }

        public Ticket Update(int id, UpdateTicketDto updateTicketDto)
        {
            var updatedTicket = _repository.Update(id, updateTicketDto);
            return updatedTicket;
        }

        public Ticket Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}