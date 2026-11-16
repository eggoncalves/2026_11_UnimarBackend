using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification.Interface;

namespace Unimar.ProjetoAcademico.ApplicationService.Interfaces.UoW
{
    public interface IUnitOfWork : IServiceNotification
    {
        Task<int> CommitAsync();
    }
}
