using backend_carhelp.shared.Infrastructure.Persistence.EFC.Configuration;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Repositories;
using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Repositories;

namespace backend_carhelp.Workshop_management.Infrastructure.Persistence.EFC.Repositories;

public class AdvertasingRepository(AppDbContext context): BaseRepository<Advertasing>(context),IAdvertasingRepository
{
    
}