using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Users.Domain.Model.Entities;

namespace backend_carhelp.Iam.Domain.Services;

public interface INotificationCommandService
{
    Task<Notification?> Handle(CreateNotificationCommand command);
    Task Handle(DeleteNotificationCommand command);
}