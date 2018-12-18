
using System;
using SMH.Models.Entidades.UsuarioEntidades;
using SMH.Models.Requests;

namespace SMH.Models.ServiciosDeDominio
{
    public interface IUsuarioDomainService : IDisposable
    {
        Usuario CrearUsuario(UsuarioRequest nuevoUsuario);
    }
}