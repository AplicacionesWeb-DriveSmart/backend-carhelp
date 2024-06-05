using backend_carhelp.Iam.Domain.Model.Aggregates;
using backend_carhelp.Iam.Interfaces.REST.Resources;

namespace backend_carhelp.Iam.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.FullName, entity.EmailAddress, entity.StreetAddress, entity.Username,
            entity.ImageUrl);
    }
}