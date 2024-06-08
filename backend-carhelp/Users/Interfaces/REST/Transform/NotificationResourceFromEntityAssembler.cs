using backend_carhelp.Iam.Interfaces.REST.Resources;
using backend_carhelp.Users.Domain.Model.Entities;

namespace backend_carhelp.Iam.Interfaces.REST.Transform;

public class NotificationResourceFromEntityAssembler
{
    public static NotificationResource ToResourceFromEntity(Notification entity)
    {
        return new NotificationResource(entity.UserId, entity.Id);
    }
}