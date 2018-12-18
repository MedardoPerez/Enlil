using System;
using System.Collections.Generic;
using SMH.Models.DTOs.UsuarioDTOs;
using SMH.Models.Requests;

namespace SMH.Models.ServiciosDeAplicacion
{
    public interface IUsuarioAppService : IDisposable
    {
        IEnumerable<UsuarioDTO> ObtenerUsuarios();

        UsuarioDTO ObtenerUsuario(UsuarioRequest request);

        UsuarioDTO CrearUsuario(UsuarioRequest request);
    } 
}