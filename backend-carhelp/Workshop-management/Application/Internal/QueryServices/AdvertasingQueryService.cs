using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Model.Queries;
using backend_carhelp.Workshop_management.Domain.Repositories;
using backend_carhelp.Workshop_management.Domain.Services;

namespace backend_carhelp.Workshop_management.Application.Internal.QueryServices;

public class AdvertasingQueryService(IAdvertasingRepository advertasingRepository): IAdvertasingQueryService
{
    public async Task<IEnumerable<Advertasing>> Handle(GetAllAdvertasingQuery query)
    {
        return await advertasingRepository.ListAsync();
    }
    public async Task<Advertasing?> Handle(GetAdvertasingByIdQuery query)
    {
        return await advertasingRepository.FindByIdAsync(query.AdvertasingId);
    }
}
