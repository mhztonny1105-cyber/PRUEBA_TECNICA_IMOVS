using System.Threading.Tasks;
using System.Web.Http;
using CompanyManagement.Api.Models.DTOs;
using CompanyManagement.Api.Models.Responses;
using CompanyManagement.Api.Services.Contracts;


namespace CompanyManagement.Api.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _svc;
        public ProductsController(IProductService svc) { _svc = svc; }


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
        public async Task<IHttpActionResult> Create([FromBody] ProductDto dto)
        {
            var data = await _svc.CreateAsync(dto);
            return Created($"/api/products/{data.Id}", ApiResponse<object>.Ok(data));
        }


        [HttpPut, Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] ProductDto dto)
        {
            var data = await _svc.UpdateAsync(id, dto);
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