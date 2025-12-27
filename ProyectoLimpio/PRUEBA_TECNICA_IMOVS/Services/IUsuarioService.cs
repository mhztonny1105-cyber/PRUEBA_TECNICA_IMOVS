using System.Collections.Generic;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioDto> GetAll();
        UsuarioDto GetById(long id);
    }
}
