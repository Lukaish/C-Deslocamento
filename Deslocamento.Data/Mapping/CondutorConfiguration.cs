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
    public class CondutorConfiguration : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {

            builder.HasKey(cd => cd.Id);

            builder.ToTable("Condutor");

            builder.Property(cd => cd.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasMaxLength(200);

            builder.Property(cd => cd.Email)
               .IsRequired()
               .HasColumnName("Email")
               .HasMaxLength(100);
        }
    }
}
