using System.Collections.Generic;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public class CustomerService
    {
        private readonly Context _db = new Context();

        public IEnumerable<Customer> GetAll() => _db.Customers.OrderByDescending(c => c.Id).ToList();
        public Customer GetById(int id) => _db.Customers.Find(id);
        public Customer Create(Customer e) { _db.Customers.Add(e); _db.SaveChanges(); return e; }
        public Customer Update(int id, Customer e)
        {
            var dbc = _db.Customers.Find(id); if (dbc == null) return null;
            dbc.Name = e.Name; dbc.Email = e.Email; dbc.Phone = e.Phone;
            _db.SaveChanges(); return dbc;
        }
        public bool Delete(int id) { var dbc = _db.Customers.Find(id); if (dbc == null) return false; _db.Customers.Remove(dbc); _db.SaveChanges(); return true; }
    }
}
