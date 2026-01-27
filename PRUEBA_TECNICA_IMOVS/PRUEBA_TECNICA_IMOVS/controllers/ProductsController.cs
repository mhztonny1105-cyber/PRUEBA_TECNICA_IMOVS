using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Responses;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;
using System;
using System.Net;
using System.Web.Http;

[RoutePrefix("api/products")]
public class ProductsController : ApiController
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    // GET api/products
    [HttpGet]
    [Route("")]
    public IHttpActionResult GetAll()
    {
        var products = _service.GetAll();
        return Ok(ApiResponse<object>.Ok(products));
    }

    // GET api/products/{id}
    [HttpGet]
    [Route("{id:guid}")]
    public IHttpActionResult GetById(Guid id)
    {
        // Service lanza KeyNotFoundException si no existe
        var product = _service.GetById(id);
        return Ok(ApiResponse<object>.Ok(product));
    }

    // POST api/products
    [HttpPost]
    [Route("")]
    public IHttpActionResult Create([FromBody] ProductCreateDto dto)
    {
        if (dto == null)
            return BadRequest("El body es obligatorio");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _service.Create(dto);

        return Content(
            HttpStatusCode.Created,
            ApiResponse<string>.Ok(null, "Producto creado")
        );
    }

    // PUT api/products/{id}
    [HttpPut]
    [Route("{id:guid}")]
    public IHttpActionResult Update(Guid id, [FromBody] ProductCreateDto dto)
    {
        if (dto == null)
            return BadRequest("El body es obligatorio");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _service.Update(id, dto);

        return Ok(ApiResponse<string>.Ok(null, "Producto actualizado"));
    }

    // DELETE api/products/{id}
    [HttpDelete]
    [Route("{id:guid}")]
    public IHttpActionResult Delete(Guid id)
    {
        _service.Delete(id);
        return Ok(ApiResponse<string>.Ok(null, "Producto eliminado"));
    }
}
