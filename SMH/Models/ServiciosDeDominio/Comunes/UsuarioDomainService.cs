using System;
using SMH.Models.Entidades.UsuarioEntidades;
using SMH.Models.Requests;

namespace SMH.Models.ServiciosDeDominio
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        public Usuario CrearUsuario(UsuarioRequest nuevoUsuario)
        {
            if (nuevoUsuario == null) throw new ArgumentNullException(nameof(nuevoUsuario));
            if(nuevoUsuario.RequestUserInfo == null) throw new ArgumentNullException(nameof(nuevoUsuario.RequestUserInfo));
            if (string.IsNullOrEmpty(nuevoUsuario.UsuarioId)) throw new ArgumentNullException(nameof(nuevoUsuario.UsuarioId));
            if (string.IsNullOrEmpty(nuevoUsuario.Nombre)) throw new ArgumentNullException(nameof(nuevoUsuario.Nombre));
            if (string.IsNullOrEmpty(nuevoUsuario.Contrasenia)) throw new ArgumentNullException(nameof(nuevoUsuario.Contrasenia));

           var  UId =  Guid.NewGuid();
            return new Usuario
            {
                UsuarioId = nuevoUsuario.UsuarioId,
                Nombre = nuevoUsuario.Nombre,
                Contrasena = nuevoUsuario.Contrasenia,
                DescripcionTransaccion = "Added",
                FechaTransaccion = DateTime.Now,
                ModificadoPor = nuevoUsuario.RequestUserInfo.UserId ?? "Anonimo",
                TipoTransaccion = "Insert",
                TransaccionUId = UId.ToString()
            };
        }

        public void Dispose()
        {
        }
    }
}