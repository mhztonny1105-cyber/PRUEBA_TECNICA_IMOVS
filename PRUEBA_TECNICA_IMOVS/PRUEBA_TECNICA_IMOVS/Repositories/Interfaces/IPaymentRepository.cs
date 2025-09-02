using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Payment GetAll();
        Payment GetById(int id);
        Payment Create(Payment payment);
        Payment Update(int id, Payment payment);
        Payment Delete(int id);
    }
}