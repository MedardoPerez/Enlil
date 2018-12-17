using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartH.Models.Entidades.Aplicacion.Comunes;

namespace SmartH.Models.Maps.Usuarios
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(r => r.UsuarioId);
            builder.Property(r => r.UsuarioId).HasColumnName("UsuarioId");
            builder.Property(r => r.Contrasena).HasColumnName("Contrasena");
            builder.Property(r => r.Nombre).HasColumnName("Nombre").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(t => t.FechaTransaccion).HasColumnName("FechaTransaccion");
            builder.Property(t => t.DescripcionTransaccion).HasColumnName("DescripcionTransaccion").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(t => t.ModificadoPor).HasColumnName("ModificadoPor").IsRequired().IsUnicode(false).HasMaxLength(20);
            builder.Property(t => t.TipoTransaccion).HasColumnName("TipoTransaccion").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(t => t.TransaccionUId).HasColumnName("TransaccionUId");
        }

    }
}