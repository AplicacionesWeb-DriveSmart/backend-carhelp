using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Interfaces.REST.Resources;

namespace backend_carhelp.Iam.Interfaces.REST.Transform;

public static class DeleteUserCommandFromResourceAssembler
{
    public static DeleteUserCommand ToCommandFromResource(DeleteUserResource resource)
    {
        return new DeleteUserCommand(resource.Id);
    }
}