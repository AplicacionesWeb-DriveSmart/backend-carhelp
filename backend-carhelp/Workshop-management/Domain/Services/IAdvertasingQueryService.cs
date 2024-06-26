using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Model.Queries;

namespace backend_carhelp.Workshop_management.Domain.Services;

public interface IAdvertasingQueryService
{
    Task<IEnumerable<Advertasing>> Handle(GetAllAdvertasingQuery query);
    Task<Advertasing> Handle(GetAdvertasingByIdQuery query);
}