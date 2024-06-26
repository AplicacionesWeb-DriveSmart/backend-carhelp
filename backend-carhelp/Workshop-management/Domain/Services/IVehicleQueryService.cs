using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Model.Queries;

namespace backend_carhelp.Workshop_management.Domain.Services;

public interface IVehicleQueryService
{
    Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query);
    Task<Vehicle?> Handle(GetVehicleByIdQuery query);
    
}