using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Interfaces.REST.Resources;

namespace backend_carhelp.Workshop_management.Interfaces.REST.Transform;

public static class AdvertisingResourceFromEntityAssembler
{
    public static AdvertasingResource ToResourceFromEntity(Advertising entity) =>
        new AdvertasingResource(entity.Id, entity.Name, entity.ImageUrl, entity.Slogan, entity.Message, entity.WorkshopId);
}