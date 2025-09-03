using System.Threading.Tasks;
using System.Web.Http;
using CompanyManagement.Api.Models.DTOs;
using CompanyManagement.Api.Models.Responses;
using CompanyManagement.Api.Services.Contracts;


namespace CompanyManagement.Api.Controllers
{
    [RoutePrefix("api/payments")]
    public class PaymentsController : ApiController
    {
        private readonly IPaymentService _svc;
        public PaymentsController(IPaymentService svc) { _svc = svc; }


        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var data = await _svc.GetAllAsync();
            return Ok(ApiResponse<object>.Ok(data));
        }


        [HttpGet, Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var data = await _svc.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(ApiResponse<object>.Ok(data));
        }


        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Create([FromBody] PaymentCreateDto dto)
        {
            var ticketDetail = await _svc.CreateAsync(dto);
            return Created($"/api/tickets/{ticketDetail.Id}", ApiResponse<object>.Ok(ticketDetail));
        }


        [HttpDelete, Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _svc.DeleteAsync(id);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}