using SMH.Models.Entidades;
using SMH.Models.Infraestructura;

namespace SMH.Models.Repositorios
{
    public class RepositorioGenerico<TEntity> : Repositorio<TEntity>, IRepositorioGenerico<TEntity>
     where TEntity : Entity
    {
        public RepositorioGenerico(UnitOfWorkSMH unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}