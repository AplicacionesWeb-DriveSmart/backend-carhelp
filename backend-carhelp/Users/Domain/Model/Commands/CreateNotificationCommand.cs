namespace backend_carhelp.Iam.Domain.Model.Commands;

public record CreateNotificationCommand(string Type, string Title, string Message, string Timestamp, bool Read, int UserId);