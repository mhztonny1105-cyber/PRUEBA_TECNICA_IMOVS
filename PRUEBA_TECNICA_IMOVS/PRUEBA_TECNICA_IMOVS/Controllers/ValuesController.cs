using System.Web.Http;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    // No usa [Route], así que usa la ruta convencional: api/{controller}
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            return Ok(new[] { "ok", "api funcionando" });
        }
    }
}
