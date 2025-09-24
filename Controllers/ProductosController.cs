using PRUEBA_TECNICA_IMOVS.Models;
using System.Linq;
using System.Web.Http;

public class ProductosController : ApiController
{
    private readonly AppDbContext _context = new AppDbContext();

    // GET: api/productos
    [HttpGet]
    public IHttpActionResult Get()
    {
        var productos = _context.Productos.ToList();
        return Ok(productos);
    }

    // GET: api/productos/5
    [HttpGet]
    public IHttpActionResult Get(int id)
    {
        var prod = _context.Productos.Find(id);
        if (prod == null) return NotFound();
        return Ok(prod);
    }

    // POST: api/productos
    [HttpPost]
    public IHttpActionResult Post(Producto p)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Productos.Add(p);
        _context.SaveChanges();
        return Ok(p);
    }

    // PUT: api/productos/5
    [HttpPut]
    public IHttpActionResult Put(int id, Producto p)
    {
        var existing = _context.Productos.Find(id);
        if (existing == null) return NotFound();

        existing.Nombre = p.Nombre;
        existing.PrecioUnitario = p.PrecioUnitario;
        _context.SaveChanges();

        return Ok(existing);
    }

    // DELETE: api/productos/5
    [HttpDelete]
    [Route("api/productos/{id}")]
    public IHttpActionResult Delete(int id)
    {
        var prod = _context.Productos.Find(id);
        if (prod == null) return NotFound();

        _context.Productos.Remove(prod);
        _context.SaveChanges();

        return Ok($"Producto {id} eliminado correctamente");
    }


}
