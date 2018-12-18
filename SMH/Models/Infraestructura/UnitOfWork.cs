using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SMH.Models.Entidades;
using SMH.Models.Entidades.UsuarioEntidades;
using SMH.Models.Maps;

namespace SMH.Models.Infraestructura
{
    public class UnitOfWork : DbContext
    {
        public UnitOfWork(DbContextOptions<DbContext> options) : base(options)
        { }

        // public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }

        #region Implementation of IQueryableUnitOfWork

        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item) where TEntity : class
        {
            //attach and set as unchanged
            Entry(item).State = EntityState.Unchanged;
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            throw new NotImplementedException();
            // return Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public void Commit(TransactionInfo transactionInfo)
        {
            ChangeTracker.DetectChanges();

             base.SaveChanges();
        }

        #endregion
    }
}