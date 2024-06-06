using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Interfaces.REST.Resources;

namespace backend_carhelp.Iam.Interfaces.REST.Transform;

public class CreateCustomerCommandFromResourceAssembler
{
    public static CreateCustomerCommand ToCommandFromResource(CreateCustomerResource resource)
    {
        return new CreateCustomerCommand(resource.UserId, resource.Id);
    }
}