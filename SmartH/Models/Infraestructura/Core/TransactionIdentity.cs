using System;

namespace SmartH.Models.Infraestructura.Core
{
    public class TransactionIdentity
    {
        /// <summary>
        /// Identity's transaction.
        /// </summary>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Server's Date and Time
        /// </summary>
        public DateTime TransactionDate { get; set; }
    }
}