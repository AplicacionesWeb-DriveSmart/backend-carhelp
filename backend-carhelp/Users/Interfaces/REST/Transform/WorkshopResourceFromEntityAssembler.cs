using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.Iam.Interfaces.REST.Resources;

namespace backend_carhelp.Iam.Interfaces.REST.Transform;

public class WorkshopResourceFromEntityAssembler
{
    public static WorkshopResource ToResourceFromEntity(Workshop entity)
    {
        return new WorkshopResource(entity.UserId, entity.Id);
    }
}