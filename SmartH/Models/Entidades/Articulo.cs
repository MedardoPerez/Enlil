using System.Collections.Generic;

namespace SmartH.Models.Entidades
{
    public class Articulo : Entity
    {
        public string ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool PagaImpuesto { get; set; }
        public virtual ICollection<PaqueteDetalle> PaqueteDetalle { get; set; }
    }
}