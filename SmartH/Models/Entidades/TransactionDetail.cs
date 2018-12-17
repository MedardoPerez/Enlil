using System;

namespace SmartH.Models.Entidades
{
    public class TransactionDetail
    {
        public Guid TransactionId { get; set; }
        public string TableName { get; set; }
        public string CrudOperation { get; set; }
        public string TransactionType { get; set; }
    }
}