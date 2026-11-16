using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unimar.ProjetoAcademico.Domain.Entities;

namespace Unimar.ProjetoAcademico.Infra.Data.Configurations
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.CursoId)
                .IsRequired();

            builder.ToTable("TB_Aluno");
        }
    }
}
