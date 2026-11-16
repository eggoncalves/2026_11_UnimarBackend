using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unimar.ProjetoAcademico.Domain.Entities;

namespace Unimar.ProjetoAcademico.Infra.Data.Configurations
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Periodo)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(p => p.CargaHoraria)
                .IsRequired();

            builder.Property(p => p.QuantidadeMaximaAlunos)
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .IsRequired();

            builder.ToTable("TB_Curso");
        }
    }
}
