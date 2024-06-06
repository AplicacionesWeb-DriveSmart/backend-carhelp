using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.Iam.Interfaces.REST.Resources;

namespace backend_carhelp.Iam.Interfaces.REST.Transform;

public class CustomerResourceFromEntityAssembler
{
    public static CustomerResource ToResourceFromEntity(Customer entity)
    {
        return new CustomerResource(entity.UserId, entity.Id);
    }
}