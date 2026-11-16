using FluentValidation.Results;
using Unimar.ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;
using Unimar.ProjetoAcademico.Infra.CrossCutting.NotificationPattern.Interface;

namespace Unimar.ProjetoAcademico.Infra.CrossCutting.NotificationPattern;

/// <summary>
/// Implementação padrão de INotifiable. Classes que precisam acumular erros herdam desta.
/// </summary>
public class Notifiable : INotifiable
{
    // Lista interna e privada. "[]" é a collection expression do C# 12 (equivale a new List<Notification>()).
    private readonly List<Notification> _notifications = [];

    // Exposição somente leitura da lista interna.
    public IReadOnlyCollection<Notification> Notifications => _notifications;

    public void AddNotification(string property, string message)
    {
        _notifications.Add(new Notification(property, message));
    }

    public void AddNotification(Notification notification)
    {
        _notifications.Add(notification);
    }

    // Usado para "propagar" notificações de um objeto para outro (ex.: Handler -> AppService).
    public void AddNotifications(IReadOnlyCollection<Notification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    // Converte cada erro do FluentValidation em uma Notification.
    public void AddNotifications(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddNotification(error.PropertyName, error.ErrorMessage);
        }
    }

    // Sobrecarga extra: aceita diretamente a lista de falhas do FluentValidation.
    public void AddNotifications(IEnumerable<ValidationFailure> failures)
    {
        foreach (var failure in failures)
        {
            AddNotification(failure.PropertyName, failure.ErrorMessage);
        }
    }

    public void ClearNotifications()
    {
        _notifications.Clear();
    }

    // Expression-bodied members (=>): métodos de uma linha só.
    public bool IsInvalid() => _notifications.Count > 0;

    public bool IsValid() => _notifications.Count == 0;
}