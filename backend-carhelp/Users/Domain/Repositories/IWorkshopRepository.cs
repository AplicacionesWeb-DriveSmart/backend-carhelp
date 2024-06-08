using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.shared.Domain.Repositories;

namespace backend_carhelp.Iam.Domain.Repositories;

public interface IWorkshopRepository : IBaseRepository<Workshop>
{
    Task DeleteWorkshopByIdAsync(int id);
    Task<Workshop> GetByUserIdAsync(int UserId);
}