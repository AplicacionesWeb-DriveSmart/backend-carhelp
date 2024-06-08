using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.Iam.Domain.Repositories;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Configuration;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Repositories;

namespace backend_carhelp.Iam.Infrastructure.Persistence.EFC.Repositories;

public class WorkshopRepository(AppDbContext context) : BaseRepository<Workshop>(context), IWorkshopRepository
{
    public async Task DeleteWorkshopByIdAsync(int id)
    {
        var workshop = await Context.Set<Workshop>().FindAsync(id);
        if (workshop != null)
        {
            Context.Set<Workshop>().Remove(workshop);
            await Context.SaveChangesAsync();
        }
    }
}