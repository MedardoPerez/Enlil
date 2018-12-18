using System.Collections.Generic;

namespace SMH.Models.Repositorios
{
    public interface ISql
    {
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);
    }
}