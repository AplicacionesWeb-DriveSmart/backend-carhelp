using backend_carhelp.shared.Domain.Repositories;
using backend_carhelp.Workshop_management.Domain.Model.Aggregates;

namespace backend_carhelp.Workshop_management.Domain.Repositories;

public interface IVehicleRepository : IBaseRepository<Vehicle>
{
    Task<Vehicle> FindAllAsync();
    Task<Vehicle> FindVehicleByIdAsync(int id);
    Task<Vehicle> GetByIdAsync(int id);
}   