using backend_carhelp.Iam.Domain.Model.Aggregates;
using backend_carhelp.Iam.Domain.Repositories;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Configuration;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Repositories;
using backend_carhelp.Users.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_carhelp.Iam.Infrastructure.Persistence.EFC.Repositories;

public class NotificationRepository(AppDbContext context) : BaseRepository<Notification>(context), INotificationRepository
{
    public async Task DeleteNotificationByIdAsync(int id)
    {
        var notification = await Context.Set<Notification>().FindAsync(id);
        if (notification != null)
        {
            Context.Set<Notification>().Remove(notification);
            await Context.SaveChangesAsync();
        }
    }

    public async Task<Notification> GetByIdAsync(int id)
    {
        return await context.Notifications.FindAsync(id);
    }

    public async Task<IEnumerable<Notification>> GetAllNotifications() =>
        await context.Set<Notification>()
            .Include(notification => notification.User)
            .ToListAsync();
}