using SMH.Models.Entidades;

namespace SMH.Models.Repositorios
{
    public interface IUnitOfWork
    {
        void Commit(TransactionInfo transactionInfo);
    }
}