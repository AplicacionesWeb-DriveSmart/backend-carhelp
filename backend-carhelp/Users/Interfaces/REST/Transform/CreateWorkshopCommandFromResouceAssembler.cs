using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Interfaces.REST.Resources;

namespace backend_carhelp.Iam.Interfaces.REST.Transform;

public class CreateWorkshopCommandFromResouceAssembler
{
    public static CreateWorkshopCommand ToCommandFromResource(CreateWorkshopResource resource)
    {
        return new CreateWorkshopCommand(resource.UserId);
    }
}