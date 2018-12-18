using System;
using System.Collections.Generic;
using System.Linq;
using SMH.Models.DTOs.UsuarioDTOs;
using SMH.Models.Entidades.UsuarioEntidades;
using SMH.Models.Repositorios;

namespace SMH.Models.ServiciosDeAplicacion
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IRepositorioGenerico<Usuario> _usuarioRepositorio;
        public UsuarioAppService(IRepositorioGenerico<Usuario> usuarioRepositorio)
        {
            if (usuarioRepositorio == null) throw new ArgumentNullException("Usuario repositorio");

            _usuarioRepositorio = usuarioRepositorio;
        }
        public IEnumerable<UsuarioDTO> ObtenerUsuarios()
        {
            var usuario = _usuarioRepositorio.GetAll();

            return usuario.Select(c => new UsuarioDTO { UsuarioId = c.UsuarioId, Nombre = c.Nombre, Contrasena = c.Contrasena }).ToList();
        }
        public void Dispose()
        {
            if (_usuarioRepositorio != null) _usuarioRepositorio.Dispose();
        }
    }
}