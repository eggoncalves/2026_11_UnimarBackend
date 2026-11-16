using Unimar.ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;

namespace Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification.Interface;

/// <summary>
/// Contrato para serviços que expõem seu estado de validação.
/// </summary>
public interface IServiceNotification
{
    bool IsServiceValid { get; }                                    // true se não há notificações
    bool IsServiceInvalid { get; }                                  // true se há notificações
    IReadOnlyCollection<Notification> ServiceNotifications { get; } // as notificações em si
}