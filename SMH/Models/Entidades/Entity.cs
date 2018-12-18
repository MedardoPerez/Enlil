using System;

namespace SMH.Models.Entidades
{
    public abstract class Entity
    {
        private string aplicacion;
        private string computadora;
        private string formulario;

        protected Entity()
        {

        }
        protected Entity(string modificadoPor, string aplicacion, string computadora, string formulario)
        {
            ModificadoPor = modificadoPor;
            this.aplicacion = aplicacion;
            this.computadora = computadora;
            this.formulario = formulario;
        }

        public string ModificadoPor { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string DescripcionTransaccion { get; set; }
        public string TransaccionUId { get; set; }
        public string TipoTransaccion { get; set; }
    }
}