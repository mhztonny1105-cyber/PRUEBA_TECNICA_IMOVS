using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Repositories.Interfaces;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public class PaymentService: IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public Payment GetAll()
        {
            var payments = _repository.GetAll();
            return payments;
        }

        public Payment GetById(int id)
        {
            var payment = _repository.GetById(id);
            return payment;
        }

        public Payment Create(CreatePaymentDto createPaymentDto)
        {
            var payment = _repository.Create(createPaymentDto);
            return payment;
        }

        public Payment Update(int id, UpdatePaymentDto updatePaymentDto)
        {
            var updatedPayment = _repository.Update(id, updatePaymentDto);
            return updatedPayment;
        }

        public Payment Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}