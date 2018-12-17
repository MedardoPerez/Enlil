using SmartH.Models.Entidades;

namespace SmartH.Models.Infraestructura.Core
{
    public class RepositorioGenerico<TEntity> : Repository<TEntity>, IRepositorioGenerico<TEntity>
     where TEntity : Entity
    {
        public RepositorioGenerico(UnitOfWorkSmh unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}