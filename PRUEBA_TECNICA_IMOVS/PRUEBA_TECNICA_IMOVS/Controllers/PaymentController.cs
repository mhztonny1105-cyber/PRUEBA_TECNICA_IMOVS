using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class PaymentController
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpGet, Route("api/payments")]
        public IHttpActionResult GetAll()
        {
            var payments = _service.GetAll();
            return Ok(payments);
        }

        [HttpGet, Route("api/payments/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var payment = _service.GetById(id);
            return Ok(payment);
        }

        [HttpPost, Route("api/payments")]
        public IHttpActionResult Create(CreatePaymentDto createPaymentDto)
        {
            var payment = _service.Create(createPaymentDto);
            return Ok(payment);
        }

        [HttpPut, Route("api/payments/{id:int}")]
        public IHttpActionResult Update(int id, UpdatePaymentDto updatePaymentDto)
        {
            var updatedPayment = _service.Update(id, updatePaymentDto);
            return Ok(updatedPayment);
        }

        [HttpDelete, Route("api/payments/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Payment deleted successfully");
        }
    }
}