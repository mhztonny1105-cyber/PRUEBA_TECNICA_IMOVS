using System.Collections.Generic;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Repositories;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IRepository<Producto> _productoRepository;

        public ProductoService()
        {
            _productoRepository = new Repository<Producto>(new Context());
        }

        public ProductoService(IRepository<Producto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public IEnumerable<ProductoDto> GetAll()
        {
            return _productoRepository.GetAll().Select(producto => new ProductoDto
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                PrecioUnitario = producto.PrecioUnitario,
                Estatus = producto.Estatus
            }).ToList();
        }

        public ProductoDto GetById(long id)
        {
            var producto = _productoRepository.GetById(id);
            if (producto == null) return null;

            return new ProductoDto
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                PrecioUnitario = producto.PrecioUnitario,
                Estatus = producto.Estatus
            };
        }
    }
}
