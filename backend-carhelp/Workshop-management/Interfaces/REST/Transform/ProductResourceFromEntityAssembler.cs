using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Interfaces.REST.Resources;

namespace backend_carhelp.Workshop_management.Interfaces.REST.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product entity) =>
        new ProductResource(entity.Id, entity.Name, entity.Quantity, entity.Price, entity.ImageUrl, entity.WorkshopId);
}