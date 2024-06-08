using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Interfaces.REST.Resources;

namespace backend_carhelp.Workshop_management.Interfaces.REST.Transform;

public static class VehicleResourceFromEntityAssembler
{
    public static VehicleResource ToResourceFromEntity(Vehicle entity)
    {
        return new VehicleResource(entity.Id, entity.Plate, entity.Brand, entity.ModelInfoFunc, entity.Colour,
            entity.ImageUrl, entity.Mileage);
    }
}