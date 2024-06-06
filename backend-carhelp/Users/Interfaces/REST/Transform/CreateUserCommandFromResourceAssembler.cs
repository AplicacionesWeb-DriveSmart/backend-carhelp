using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Interfaces.REST.Resources;

namespace backend_carhelp.Iam.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(resource.FirstName, resource.LastName, resource.Email,resource.PhoneNumber,resource.Street,resource.Number,resource.City,resource.PostalCode,resource.Country,resource.Password,resource.Username,resource.ImageUrl);
    }
}