using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Interfaces.REST.Resources;

namespace backend_carhelp.Iam.Interfaces.REST.Transform;

public class DeleteNotificationCommandFromResourceAssembler
{
    public static DeleteNotificationCommand ToCommandFromResource(DeleteNotificationResource resource)
    {
        return new DeleteNotificationCommand(resource.NotificationId);
    }
}