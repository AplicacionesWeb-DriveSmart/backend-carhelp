using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.Iam.Domain.Model.Queries;

namespace backend_carhelp.Iam.Domain.Services;

public interface IWorkshopQueryService
{
    Task<IEnumerable<Workshop>> Handle(GetAllWorkshopQuery query);
    Task<Workshop?> Handle(GetWorkshopByIdQuery query);
}