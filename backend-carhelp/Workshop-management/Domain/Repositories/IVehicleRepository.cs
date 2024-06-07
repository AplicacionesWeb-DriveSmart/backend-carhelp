using backend_carhelp.shared.Domain.Repositories;
using backend_carhelp.Workshop_management.Domain.Model.Aggregates;

namespace backend_carhelp.Workshop_management.Domain.Repositories;

public interface IVehicleRepository : IBaseRepository<Vehicle>
{
    Task<IEnumerable<Vehicle>> FindAllAsync();
    Task<IEnumerable<Vehicle>> FindByIdAsync(int id);
}   