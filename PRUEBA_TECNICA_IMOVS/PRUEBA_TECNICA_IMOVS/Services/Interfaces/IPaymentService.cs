using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public interface IPaymentService
    {
        Payment GetAll();
        Payment GetById(int id);
        Payment Create(CreatePaymentDto createPaymentDto);
        Payment Update(int id, UpdatePaymentDto updatePaymentDto);
        Payment Delete(int id);
    }
}