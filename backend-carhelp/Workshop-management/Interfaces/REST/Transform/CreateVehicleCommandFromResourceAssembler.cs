using backend_carhelp.Workshop_management.Domain.Model.Commands;
using backend_carhelp.Workshop_management.Interfaces.REST.Resources;

namespace backend_carhelp.Workshop_management.Interfaces.REST.Transform;

public class CreateVehicleCommandFromResourceAssembler
{
    public static CreateVehicleCommand ToCommandFromResource(CreateVehicleResource resource)
    {
        return new CreateVehicleCommand(resource.Plate, resource.Brand, resource.Model, resource.Year, resource.Colour,
            resource.ImageUrl, resource.Mileage);
    }
}