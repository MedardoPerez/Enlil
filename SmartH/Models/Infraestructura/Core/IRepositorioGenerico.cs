using SmartH.Models.Entidades;

namespace SmartH.Models.Infraestructura.Core
{
    public interface IRepositorioGenerico<TEntity> : IRepository<TEntity>
       where TEntity : Entity
    {
    }
}