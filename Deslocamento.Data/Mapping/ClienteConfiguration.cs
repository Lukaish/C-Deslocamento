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
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(cl => cl.Id);

            builder.ToTable("Cliente");

            builder.Property(cl => cl.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasMaxLength(200);

            builder.Property(cl => cl.Cpf)
               .IsRequired()
               .HasColumnName("Cpf")
               .HasMaxLength(11);
        }
    }
}
