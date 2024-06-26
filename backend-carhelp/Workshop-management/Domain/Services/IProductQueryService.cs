using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Model.Queries;

namespace backend_carhelp.Workshop_management.Domain.Services;

public interface IProductQueryService
{
    Task<IEnumerable<Product>> Handle(GetAllProductQuery query);
    Task<Product> Handle(GetProductByIdQuery query);
}