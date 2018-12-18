using System;
using System.Collections.Generic;
using SMH.Models.DTOs.UsuarioDTOs;

namespace SMH.Models.ServiciosDeAplicacion
{
    public interface IUsuarioAppService : IDisposable
    {
        IEnumerable<UsuarioDTO> ObtenerUsuarios();
    } 
}