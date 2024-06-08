namespace backend_carhelp.Iam.Interfaces.REST.Resources;

public record CreateNotificationResource(string Type, string Title, string Message, string Timestamp, bool Read, int UserId);