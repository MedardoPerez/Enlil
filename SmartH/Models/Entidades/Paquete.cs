using System.Collections.Generic;

namespace SmartH.Models.Entidades
{
    public class Paquete : Entity
    {
        public int PaqueteId { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public decimal Ganancia { get; set; }
        public virtual ICollection<PaqueteDetalle> PaqueteDetalle { get; set; }

        public void RemoverPaqueteDetalle()
        {
            if (PaqueteDetalle != null)
            {
                var paqueteDetalle = new List<PaqueteDetalle>(PaqueteDetalle);

                foreach (var item in paqueteDetalle)
                {
                    item.MarcarEliminar = true;
                    PaqueteDetalle.Remove(item);
                }
            }
        }
    }
}