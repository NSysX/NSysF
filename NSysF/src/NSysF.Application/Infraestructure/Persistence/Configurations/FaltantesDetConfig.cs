using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSysF.Application.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSysF.Application.Infraestructure.Persistence.Configurations
{
    public class FaltantesDetConfig : IEntityTypeConfiguration<FaltantesDet>
    {
        public void Configure(EntityTypeBuilder<FaltantesDet> builder)
        {
            builder.HasKey(f => f.Id);

            builder.ToTable("FaltantesDet").HasComment("Tabla de faltantes de las Sucursales");

            builder.HasIndex(f => f.ClienteId, "IX_ClienteId");

            builder.HasIndex(f => f.EmpleadoId, "IX_EmpleadoId");

            builder.HasIndex(f => f.ProdMaestroId, "IX_ProdMaestroId");

            builder.HasIndex(f => new { f.ClienteId, f.EmpleadoId, f.ProdMaestroId, f.MarcaId, f.Estatus }, "IX_NoDup_FaltantesDet").IsUnique();

            builder.Property(f => f.Id).HasComment("Id Consecutivo");

            builder.Property(f => f.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasDefaultValue("F")
                .HasComment("Estatus del articulo del Faltante, F = Faltante, S = Surtido");

            builder.Property(f => f.FechaCreacion)
                .HasColumnType("datetime")
                // .HasDefaultValue(new DateTime(1900, 1, 1, 00, 00, 00, 000))
                .HasComment("Fecha de Creacion");

            builder.Property(f => f.FechaModificacion)
                .HasColumnType("datetime")
               // .HasDefaultValue(new DateTime(1900, 1, 1, 00, 00, 00, 000))
                .HasComment("Fecha de Creacion");

            builder.Property(f => f.ClienteId).HasComment("El id del Cliente");

            builder.Property(f => f.EmpleadoId).HasComment("El id del Empleado");

            builder.Property(f => f.Cantidad)
                .HasPrecision(5,3)
                .HasComment("Cantidad solicitada");

            builder.Property(f => f.ProdMaestroId).HasComment("Id del catalogo de ProdMaestro");

            builder.Property(f => f.MarcaId).HasComment("Id del Catalogo de Marcas");

            builder.Property(f => f.EsCadaUno)
                .HasDefaultValue(false)
                .HasComment("Si el precio es por unidad y no por caja");

            builder.Property(f => f.Notas)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Notas para el que va a surtir el reglon del Pedido");
        }
    }
}
