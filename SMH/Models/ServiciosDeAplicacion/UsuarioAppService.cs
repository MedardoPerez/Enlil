using System;
using System.Collections.Generic;
using System.Linq;
using SMH.Models.DTOs.UsuarioDTOs;
using SMH.Models.Entidades.UsuarioEntidades;
using SMH.Models.Recursos;
using SMH.Models.Repositorios;
using SMH.Models.Requests;
using SMH.Models.ServiciosDeDominio;

namespace SMH.Models.ServiciosDeAplicacion
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IRepositorioGenerico<Usuario> _usuarioRepositorio;
        private readonly IUsuarioDomainService _usuarioDomainService;
        public UsuarioAppService(
            IRepositorioGenerico<Usuario> usuarioRepositorio,
            IUsuarioDomainService usuarioDomainService)
        {
            if (usuarioRepositorio == null) throw new ArgumentNullException(nameof(usuarioRepositorio));
            if(usuarioDomainService == null) throw new ArgumentNullException(nameof(usuarioDomainService));

            _usuarioRepositorio = usuarioRepositorio;
            _usuarioDomainService = usuarioDomainService;
        }
        public IEnumerable<UsuarioDTO> ObtenerUsuarios()
        {
            var usuario = _usuarioRepositorio.GetAll();

            return usuario.Select(c => new UsuarioDTO { UsuarioId = c.UsuarioId, Nombre = c.Nombre, Contrasena = c.Contrasena }).ToList();
        }

        public UsuarioDTO ObtenerUsuario(UsuarioRequest request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));
            if(string.IsNullOrEmpty(request.UsuarioId)) throw new ArgumentNullException(nameof(request.UsuarioId));

            var usuario = _usuarioRepositorio.GetSingle(s => s.UsuarioId == request.UsuarioId);
            if(usuario == null) return new UsuarioDTO{ ValidationErrorMessage = "Usuario no existe"};

            return new UsuarioDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre              
            };
        }

        public UsuarioDTO CrearUsuario(UsuarioRequest request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));
            if (request.RequestUserInfo == null) throw new ArgumentNullException(nameof(request.RequestUserInfo));
            if(string.IsNullOrEmpty(request.UsuarioId)) throw new ArgumentNullException(nameof(request.UsuarioId));
            if(string.IsNullOrEmpty(request.Nombre)) throw new ArgumentNullException(nameof(request.Nombre));
            if(string.IsNullOrEmpty(request.Contrasenia)) throw new ArgumentNullException(nameof(request.Contrasenia));

           var nuevoUsuario = _usuarioDomainService.CrearUsuario(request);

           if(nuevoUsuario == null) return new UsuarioDTO{ValidationErrorMessage = "Problemas al crear usuario"};

            var transactioninfo = TransactionInfoHelper.CrearTransactionInfo(request.RequestUserInfo);
            _usuarioRepositorio.Add(nuevoUsuario);

            _usuarioRepositorio.UnitOfWork.Commit(transactioninfo);

            return new UsuarioDTO
            {
                UsuarioId = nuevoUsuario.UsuarioId,
                Nombre = nuevoUsuario.Nombre
            };
        }
        public void Dispose()
        {
            if (_usuarioRepositorio != null) _usuarioRepositorio.Dispose();
            if(_usuarioDomainService != null) _usuarioDomainService.Dispose();
        }
    }
}