namespace SMH.Models.DTOs.UsuarioDTOs
{
    public class UsuarioDTO : BaseDTO
    {
        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
    }
}