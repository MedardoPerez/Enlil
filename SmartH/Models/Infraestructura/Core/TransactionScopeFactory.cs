using System.Transactions;

namespace SmartH.Models.Infraestructura.Core
{
    public static class TransactionScopeFactory
    {
        public static TransactionScope GetTransactionScope()
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
    }
}