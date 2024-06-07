using System.Numerics;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Configuration;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Repositories;
using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_carhelp.Workshop_management.Infrastructure.Persistence.EFC.Repositories;

public class VehicleRepository(AppDbContext context) : BaseRepository<Vehicle>(context), IVehicleRepository
{
    public Task<Vehicle> FindAllAsync()
    {
        return null;
    }

    public Task<Vehicle> FindVehicleByIdAsync(int id)
    {
        return Context.Set<Vehicle>().Where(p => p.Id == id).FirstOrDefaultAsync();
    }
    
     public async Task<Vehicle> GetByIdAsync(int id)
    {
        return await context.Vehicles.FindAsync(id);
    }
}
