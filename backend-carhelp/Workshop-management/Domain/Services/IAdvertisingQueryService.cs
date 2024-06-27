using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Model.Queries;

namespace backend_carhelp.Workshop_management.Domain.Services;

public interface IAdvertisingQueryService
{
    Task<IEnumerable<Advertising>> Handle(GetAllAdvertisingQuery query);
    Task<Advertising> Handle(GetAdvertisingByIdQuery query);
}