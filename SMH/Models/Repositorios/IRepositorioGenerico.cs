using SMH.Models.Entidades;

namespace SMH.Models.Repositorios
{
    public interface IRepositorioGenerico<TEntity> : IRepositorio<TEntity>
   where TEntity : Entity
    {
    }
}