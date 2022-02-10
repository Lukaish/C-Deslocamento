    using DeslocamentoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Data.Mapping
{
    public class CarroConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey (c => c.Id);

            builder.ToTable("Carro");

            builder.Property(c => c.Placa)
                .IsRequired()
                .HasColumnName("Placa")
                .HasMaxLength(7);

            builder.Property(c => c.Descricao)
               .IsRequired()
               .HasColumnName("Descricao")
               .HasMaxLength(2000);

        }
    }
}
