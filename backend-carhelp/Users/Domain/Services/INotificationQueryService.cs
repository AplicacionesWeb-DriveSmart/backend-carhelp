using backend_carhelp.Iam.Domain.Model.Queries;
using backend_carhelp.Users.Domain.Model.Entities;

namespace backend_carhelp.Iam.Domain.Services;

public interface INotificationQueryService
{
    
    Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query);
    Task<Notification?> Handle(GetNotificationByIdQuery query);
}