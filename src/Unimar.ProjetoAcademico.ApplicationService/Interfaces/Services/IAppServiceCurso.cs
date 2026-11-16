using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Adicionar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Atualizar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Excluir;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Listar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Obter;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification.Interface;

namespace Unimar.ProjetoAcademico.ApplicationService.Interfaces.Services;

public interface IAppServiceCurso : IServiceNotification
{
    Task<CommandResponse<CursoObterResponse>> ObterAsync(CursoObterRequest request);
    Task<CommandResponse<List<CursoListarResponse>>> ListarAsync(CursoListarRequest request);
    Task<CommandResponse<CursoAdicionarResponse>> AdicionarAsync(CursoAdicionarRequest request);
    Task<CommandResponse<CursoAtualizarResponse>> AtualizarAsync(CursoAtualizarRequest request);
    Task<CommandResponse<CursoExcluirResponse>> ExcluirAsync(CursoExcluirRequest request);
}
