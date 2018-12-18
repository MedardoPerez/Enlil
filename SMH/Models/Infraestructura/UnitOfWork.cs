using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SMH.Models.Entidades.UsuarioEntidades;
using SMH.Models.Maps;

namespace SMH.Models.Infraestructura
{
    // >dotnet ef migration add testMigration
    public class UnitOfWork : DbContext
    {
        public UnitOfWork(DbContextOptions<DbContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Usuario>().HasKey(m => m.UsuarioId);

            // shadow properties
            // builder.Entity<DataEventRecord>().Property<DateTime>("UpdatedTimestamp");
            // builder.Entity<SourceInfo>().Property<DateTime>("UpdatedTimestamp");
            builder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            // updateUpdatedProperty<SourceInfo>();
            // updateUpdatedProperty<DataEventRecord>();

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
    }
}