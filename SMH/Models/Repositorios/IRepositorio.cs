using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SMH.Models.Entidades;

namespace SMH.Models.Repositorios
{
    public interface IRepositorio<TEntity> : IDisposable
 where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        IEnumerable<TEntity> GetAll();

        void Add(TEntity item);

        void AddRange(IEnumerable<TEntity> items);

        void Remove(TEntity item);

        void RemoveRange(IEnumerable<TEntity> items);

        void Merge(TEntity persisted, TEntity current);

        TEntity GetSingle(Expression<Func<TEntity, bool>> filter);

        TEntity GetSingle(Expression<Func<TEntity, bool>> filter, List<string> includes);

        IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter, List<String> includes);

        IEnumerable<TEntity> GetFiltered(Dictionary<string, object> multipleFilters);

        PagedCollection GetPagedAndFiltered(DynamicFilter filterDefinition);
    }
}