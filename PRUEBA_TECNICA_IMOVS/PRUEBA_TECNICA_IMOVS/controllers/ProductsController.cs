using PRUEBA_TECNICA_IMOVS.Models;

using System.Web.Http;
using System.Linq;

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

    }
}