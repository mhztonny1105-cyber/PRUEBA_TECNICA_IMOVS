using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController()
        {
            _usuarioService = new UsuarioService();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(_usuarioService.GetAll());
            }
            catch (System.Exception)
            {
                return InternalServerError(new System.Exception("Error al recuperar la lista de usuarios."));
            }
        }
    }
}
