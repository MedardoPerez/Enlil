namespace SMH.Models.Requests
{
    public class UsuarioRequest : RequestBase
    {
        public string UsuarioId { get; set; }   

        public string Nombre { get; set; } 

        public string Contrasenia { get; set; }
    }
}