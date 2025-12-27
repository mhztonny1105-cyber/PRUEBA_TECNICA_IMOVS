using System.Collections.Generic;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public interface IProductoService
    {
        IEnumerable<ProductoDto> GetAll();
        ProductoDto GetById(long id);
    }
}
