using System;

namespace SMH.Models.Entidades
{
    public class TransactionInfo : Entity
    {
        public TransactionInfo(string modificadoPor, string aplicacion, string computadora, string formulario)
             : base(modificadoPor, aplicacion, computadora, formulario)
        {

        }

        public TransactionInfo(string modificadoPor, string aplicacion, string computadora, string formulario, string tipoTransaccion)
            : base(modificadoPor, aplicacion, computadora, formulario)
        {
            TipoTransaccion = tipoTransaccion;
        }


        /// <summary> 
        /// Obtiene o actualiza el ultimo tipo transaccion aefectuada al articulo en proceso.
        /// </summary>
        /// <value>
        /// El tipo de transaccion.
        /// </value>
        public string TipoTransaccion { get; set; }

        /// <summary>
        /// Obtiene la fecha UTC cuando ocurrio la ultima transaccion.
        /// </summary>
        /// <value>
        /// La fecha UTC cuando se efectuo la ultima transaccion.
        /// </value>
        public DateTime FechaTransaccionUtc { get; set; }
    }
}