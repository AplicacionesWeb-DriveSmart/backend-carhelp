using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Model.Queries;
using backend_carhelp.Workshop_management.Domain.Repositories;
using backend_carhelp.Workshop_management.Domain.Services;

namespace backend_carhelp.Workshop_management.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository): IProductQueryService
{
    public async Task<IEnumerable<Product>> Handle(GetAllProductQuery query)
    {
        return await productRepository.ListAsync();
    }
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.ProductId);
    }
}