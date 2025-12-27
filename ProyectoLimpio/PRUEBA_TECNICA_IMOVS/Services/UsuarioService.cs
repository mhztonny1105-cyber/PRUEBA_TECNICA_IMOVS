using System.Collections.Generic;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Repositories;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioService()
        {
            _usuarioRepository = new Repository<Usuario>(new Context());
        }

        public UsuarioService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<UsuarioDto> GetAll()
        {
            return _usuarioRepository.GetAll().Select(usuario => new UsuarioDto
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Username = usuario.Username,
                Rol = usuario.Rol,
                Estatus = usuario.Estatus
            }).ToList();
        }

        public UsuarioDto GetById(long id)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null) return null;

            return new UsuarioDto
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Username = usuario.Username,
                Rol = usuario.Rol,
                Estatus = usuario.Estatus
            };
        }
    }
}
