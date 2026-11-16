using Unimar.ProjetoAcademico.Domain.Entities.Base;

namespace Unimar.ProjetoAcademico.Domain.Entities
{
    public class Aluno : EntityBase<int>
    {
        public string Nome { get; set; } = string.Empty;
        public Guid CursoId { get; set; }

        //Propriedade de navegação
        public Curso Curso { get; set; } = null!;
    }
}
