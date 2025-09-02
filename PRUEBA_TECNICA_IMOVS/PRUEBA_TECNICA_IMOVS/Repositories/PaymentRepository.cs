using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Repositories.Interfaces;

namespace PRUEBA_TECNICA_IMOVS.Repositories
{
    public class PaymentRepository: IPaymentRepository
    {
        private readonly Context _context;

        public PaymentRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments
                .Include(p => p.Ticket)
                .ToList();
        }

        public Payment GetById(int id)
        {
            return _context.Payments
                .Include(p => p.Ticket)
                .FirstOrDefault(p => p.Id == id);
        }

        public Payment Create(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return payment;
        }

        public Payment Update(int id, Payment payment)
        {
            
        }

        public Payment Delete(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment == null) return null;

            _context.Payments.Remove(payment);
            _context.SaveChanges();
            return payment;
        }
    }
    }
}