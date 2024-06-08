using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Interfaces.REST.Resources;

namespace backend_carhelp.Iam.Interfaces.REST.Transform;

public class DeleteWorkshopCommandFromResouceAssembler
{
    public static DeleteWorkshopCommand ToCommandFromResource(DeleteWorkshopResource resource)
    {
        return new DeleteWorkshopCommand(resource.Id);
    }
}