using System.Threading.Tasks;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Api.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Api.Models.Responses;
using PRUEBA_TECNICA_IMOVS.Api.Services.Contracts;


namespace PRUEBA_TECNICA_IMOVS.Api.Controllers
{
    [RoutePrefix("api/tickets")]
    public class TicketsController : ApiController
    {
        private readonly ITicketService _svc;
        public TicketsController(ITicketService svc) { _svc = svc; }


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
        public async Task<IHttpActionResult> Create([FromBody] TicketCreateDto dto)
        {
            var data = await _svc.CreateAsync(dto);
            return Created($"/api/tickets/{data.Id}", ApiResponse<object>.Ok(data));
        }


        [HttpPut, Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id)
        {
            var data = await _svc.UpdateAsync(id);
            if (data == null) return NotFound();
            return Ok(ApiResponse<object>.Ok(data));
        }


        [HttpDelete, Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _svc.DeleteAsync(id);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}