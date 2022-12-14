using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class LugarConfiguration : IEntityTypeConfiguration<Lugar>
    {
        public void Configure(EntityTypeBuilder<Lugar> builder)
        {
            builder.Property(l => l.Id).IsRequired();
            builder.Property(l => l.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Descripcion).IsRequired();
            builder.Property(l => l.GastoAproximado).IsRequired();
            
            /* Relationships */
            builder.HasOne(c => c.Categoria).WithMany().HasForeignKey(l => l.CategoriaId);

            builder.HasOne(p => p.Pais).WithMany().HasForeignKey(l => l.PaisId);
        }
    }
}