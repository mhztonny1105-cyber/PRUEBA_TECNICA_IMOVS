using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Repositories.Interfaces;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public class TicketDetailService: ITicketDetailService
    {
        private readonly ITicketDetailRepository _repository;

        public TicketDetailService(ITicketDetailRepository repository)
        {
            _repository = repository;
        }

        public TicketDetail GetAll()
        {
            var products = _repository.GetAll();
            return products;
        }

        public TicketDetail GetById(int id)
        {
            var product = _repository.GetById(id);
            return product;
        }

        public TicketDetail Create(CreateTicketDetailDto createTicketDetailDto)
        {
            var product = _repository.Create(createTicketDetailDto);
            return product;
        }

        public TicketDetail Update(int id, UpdateTicketDetailDto updateTicketDetailDto)
        {
            var updatedTicketDetail = _repository.Update(id, updateTicketDetailDto);
            return updatedTicketDetail;
        }

        public TicketDetail Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}