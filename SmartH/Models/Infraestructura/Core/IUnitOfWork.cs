using SmartH.Models.Entidades;

namespace SmartH.Models.Infraestructura.Core
{
    public interface IUnitOfWork
    {
        void Commit(TransactionInfo transactionInfo);
    }
}