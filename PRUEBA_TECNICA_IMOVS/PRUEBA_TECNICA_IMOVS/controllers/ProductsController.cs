using PRUEBA_TECNICA_IMOVS.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly Context _context = new Context();

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateProduct (Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Products.Add(product);
            _context.SaveChanges();

            return Content(System.Net.HttpStatusCode.Created, new
            {
                message = "El producto se creó satisfactoriamente",
                product
            });
        }
        
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetProducts()
        {
            var products = _context.Products.Where(p => p.IsActive).ToList();

            return Ok(new
            {
                message = "Los productos se obtuvieron satisfactoriamente",
                products
            });
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetProductById(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id && p.IsActive);

            if (product == null)
                return NotFound();

            return Ok(new
            {
                message = "El producto se obtuvo satisfactoriamente",
                product
            });
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, Product model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _context.Products.Find(id);

            if (product == null)
                return NotFound();

            product.Name = model.Name;
            product.Price = model.Price;
            product.IsActive = model.IsActive;

            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
                return NotFound();

            product.IsActive = false;
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}