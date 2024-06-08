using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.Iam.Domain.Model.Queries;
using backend_carhelp.Iam.Domain.Repositories;
using backend_carhelp.Iam.Domain.Services;

namespace backend_carhelp.Iam.Application.Internal.QueryServices;

public class WorkshopQueryService(IWorkshopRepository workshopRepository) : IWorkshopQueryService
{
    public async Task<IEnumerable<Workshop>> Handle(GetAllWorkshopQuery query)
    {
        return await workshopRepository.ListAsync();
    }
    
    public async Task<Workshop?> Handle(GetWorkshopByIdQuery query)
    {
        return await workshopRepository.FindByIdAsync(query.UserId);
    }

}