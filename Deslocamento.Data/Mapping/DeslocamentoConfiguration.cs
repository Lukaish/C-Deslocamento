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
    public class DeslocamentoConfiguration : IEntityTypeConfiguration<Deslocamento>
    {
        public void Configure(EntityTypeBuilder<Deslocamento> builder)
        {
            builder.HasKey(d => d.Id);

            builder.ToTable("Deslocamento");

            builder.Property(d => d.Observacao)
                .IsRequired()
                .HasColumnName("Observacao")
                .HasMaxLength(1000);

            builder.HasOne(e => e.Carro)
                .WithMany(d => d.Deslocamentos)
               .HasForeignKey(e => e.CarroId)
               .HasConstraintName("FK_Carro_Deslocamento_CarroID");

            builder.HasOne(e => e.Condutor)
               .WithMany(d => d.Deslocamentos)
              .HasForeignKey(e => e.CondutorId)
              .HasConstraintName("FK_Condutor_Deslocamento_CondutorID");

            builder.HasOne(e => e.Cliente)
               .WithMany(d => d.Deslocamentos)
              .HasForeignKey(e => e.ClienteId)
              .HasConstraintName("FK_Carro_Deslocamento_ClienteID");

            builder.Property(d => d.QuilometragemFinal)
               .HasColumnName("Quilometragem_Final")
               .HasColumnType("decimal");

            builder.Property(d => d.QuilometragemInicial)
               .HasColumnName("Quilometragem_Inicial")
               .IsRequired()
               .HasColumnType("decimal");

            builder.Property(d => d.DataHoraFim)
               .HasColumnName("Data_HoraFim")
               .HasColumnType("datetime");

            builder.Property(d => d.DataHoraRegistro)
               .HasColumnName("Data_Hora_Inicio")
               .HasColumnType("datetime");

        }
    }
}
