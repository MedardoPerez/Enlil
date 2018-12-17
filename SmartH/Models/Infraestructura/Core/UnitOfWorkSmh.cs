using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartH.Models.Entidades;
using SmartH.Models.Maps.Usuarios;

namespace SmartH.Models.Infraestructura.Core
{
    public class UnitOfWorkSmh : BCUnitOfWork, IQueryableUnitOfWork
    {
        public UnitOfWorkSmh()
            : base()
        {
            // Database.SetInitializer<UnitOfWorkSmh>(null);
        }

        // public DbSet<Usuario> Usuario { get; set; }
        // public IDbSet<Parametros> Parametros { get; set; }
        // public IDbSet<Articulo> Articulo { get; set; }
        // public IDbSet<Paquete> Paquete { get; set; }
        // public IDbSet<PaqueteDetalle> PaqueteDetalle { get; set; }
        // public IDbSet<Factura> Factura { get; set; }
        // public IDbSet<FacturaDetalle> FacturaDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // modelBuilder.Configurations.Add(new UsuarioMap());
            // modelBuilder.Configurations.Add(new ParametrosMap());
            // modelBuilder.Configurations.Add(new ArticuloMap());
            // modelBuilder.Configurations.Add(new PaqueteMap());
            // modelBuilder.Configurations.Add(new PaqueteDetalleMap());
            // modelBuilder.Configurations.Add(new FacturaMap());
            // modelBuilder.Configurations.Add(new FacturaDetalleMap());
        }

        public override void Commit(TransactionInfo transactionInfo)
        {
            // var changeInfo = ChangeTracker.Entries().Where(t => t.State == System.Data.Entity.EntityState.Modified).ToList();
            // var test = ChangeTracker.Entries();
            // if (changeInfo.Any())
            // {
            //     var listaEntidades = (from reg in changeInfo
            //                           select new
            //                           {
            //                               EntidadModificada = reg.Entity.GetType().Name
            //                           }).Distinct().ToList();

            //     foreach (var entityEntry in listaEntidades)
            //     {
            //         var entidadModificada = entityEntry.EntidadModificada;

            //         if (EntidadModificada("PaqueteDetalle", entidadModificada))
            //         {
            //             var PaqueteDetalle = ChangeTracker.Entries<PaqueteDetalle>()
            //                 .Where(a => a.State == System.Data.Entity.EntityState.Modified);
            //             foreach (var entry in PaqueteDetalle.Where(entry => entry.Entity.MarcarEliminar))
            //             {
            //                 entry.State = System.Data.Entity.EntityState.Deleted;
            //             }
            //         }
            //     }
            // }
            base.Commit(transactionInfo);
        }

        private bool EntidadModificada(string nombreEntidad, string entityEntry)
        {
            return entityEntry.Contains(nombreEntidad);
        }

    }
}