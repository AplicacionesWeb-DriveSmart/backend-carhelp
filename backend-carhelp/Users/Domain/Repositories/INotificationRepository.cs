using backend_carhelp.Iam.Domain.Model.Aggregates;
using backend_carhelp.shared.Domain.Repositories;
using backend_carhelp.Users.Domain.Model.Entities;

namespace backend_carhelp.Iam.Domain.Repositories;

public interface INotificationRepository : IBaseRepository<Notification>
{
    Task DeleteNotificationByIdAsync(int Id);
}