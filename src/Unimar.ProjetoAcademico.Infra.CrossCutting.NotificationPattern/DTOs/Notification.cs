namespace Unimar.ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs
{
    public class Notification(string property, string message)
    {
        public string Property { get; } = property;
        public string Message { get; } = message;
    }
}
