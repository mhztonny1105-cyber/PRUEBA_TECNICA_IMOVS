

using System;
using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Models.Responses;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;


namespace PRUEBA_TECNICA_IMOVS.Controllers
{

    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var products = _service.GetAll();
            return Ok(ApiResponse<object>.Ok(products));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IHttpActionResult GetById(Guid id)
        {
            var product = _service.GetById(id);
            if (product == null)
                return NotFound();

            return Ok(ApiResponse<object>.Ok(product));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(Product product)
        {
            _service.Create(product);
            return Content(HttpStatusCode.Created, ApiResponse<string>.Ok(null, "Producto creado"));
        }
    }


}