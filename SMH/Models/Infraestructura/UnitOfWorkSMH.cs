using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SMH.Models.Entidades;
using SMH.Models.Entidades.UsuarioEntidades;
using SMH.Models.Maps;
using SMH.Models.Repositorios;

namespace SMH.Models.Infraestructura
{
    public class UnitOfWorkSMH : UnitOfWork, IQueryableUnitOfWork
    {
        public UnitOfWorkSMH(DbContextOptions<DbContext> options) : base(options)
        {
            // Database.SetInitializer<UnitOfWorkSMH>(null);
        }


        public DbSet<Usuario> Usuario { get; set; }
     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var changeInfo = ChangeTracker.Entries().Where(t => t.State == EntityState.Modified).ToList();
            var test = ChangeTracker.Entries();
            if (changeInfo.Any())
            {
                var listaEntidades = (from reg in changeInfo
                                      select new
                                      {
                                          EntidadModificada = reg.Entity.GetType().Name
                                      }).Distinct().ToList();

                // foreach (var entityEntry in listaEntidades)
                // {
                //     var entidadModificada = entityEntry.EntidadModificada;

                //     if (EntidadModificada("PaqueteDetalle", entidadModificada))
                //     {
                //         var PaqueteDetalle = ChangeTracker.Entries<PaqueteDetalle>()
                //             .Where(a => a.State == EntityState.Modified);
                //         foreach (var entry in PaqueteDetalle.Where(entry => entry.Entity.MarcarEliminar))
                //         {
                //             entry.State = EntityState.Deleted;
                //         }
                //     }
                // }
            }
            return base.SaveChanges();
        }

        private bool EntidadModificada(string nombreEntidad, string entityEntry)
        {
            return entityEntry.Contains(nombreEntidad);
        }

    }
}