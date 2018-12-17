using System.Collections.Generic;

namespace SmartH.Models.Infraestructura.Core
{
    public interface ISql
    {
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);
    }
}