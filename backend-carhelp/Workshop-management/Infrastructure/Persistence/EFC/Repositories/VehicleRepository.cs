using System.Numerics;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Configuration;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Repositories;
using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_carhelp.Workshop_management.Infrastructure.Persistence.EFC.Repositories;

public class VehicleRepository(AppDbContext context) : BaseRepository<Vehicle>(context), IVehicleRepository
{
    public async Task DeleteVehicleByIdAsync(int id)
    {
        var vehicle = await Context.Set<Vehicle>().FindAsync(id);
        if (vehicle != null)
        {
            Context.Set<Vehicle>().Remove(vehicle);
            await Context.SaveChangesAsync();
        }
    }
}