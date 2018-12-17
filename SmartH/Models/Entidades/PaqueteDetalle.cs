namespace SmartH.Models.Entidades
{
    public class PaqueteDetalle : Entity
    {
        public int PaqueteDetalleId { get; set; }
        public int PaqueteId { get; set; }
        public string ArticuloId { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioCompra { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool PagaImpuesto { get; set; }
        public virtual Paquete Paquete { get; set; }

        // [NotMapped]
        public bool MarcarEliminar { get; set; }
        public virtual Articulo Articulo { get; set; }
    }
}