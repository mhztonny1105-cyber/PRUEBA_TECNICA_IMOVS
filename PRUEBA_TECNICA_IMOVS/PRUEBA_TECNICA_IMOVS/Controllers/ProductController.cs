using System.Web.Http;
using System.Web.Http.Results;
using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class ProductController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet, Route("api/products")]
        public IHttpActionResult GetAll()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpGet, Route("api/products/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            return Ok(product);
        }

        [HttpPost, Route("api/products")]
        public IHttpActionResult Create(CreateProductDto createProductDto)
        {
            var product = _service.Create(createProductDto);
            return Ok(product);
        }

        [HttpPut, Route("api/products/{id:int}")]
        public IHttpActionResult Update(int id, UpdateProductDto updateProductDto)
        {
            var updatedProduct = _service.Update(id, updateProductDto);
            return Ok(updatedProduct);
        }
        
        [HttpDelete, Route("api/products/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Product deleted successfully");
        }
    }
}