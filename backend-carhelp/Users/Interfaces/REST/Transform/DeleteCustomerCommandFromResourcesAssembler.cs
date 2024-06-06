using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Interfaces.REST.Resources;

namespace backend_carhelp.Iam.Interfaces.REST.Transform;

public class DeleteCustomerCommandFromResourcesAssembler
{
    public static DeleteCustomerCommand ToCommandFromResource(DeleteCustomerResource resource)
    {
        return new DeleteCustomerCommand(resource.Id);
    }
}