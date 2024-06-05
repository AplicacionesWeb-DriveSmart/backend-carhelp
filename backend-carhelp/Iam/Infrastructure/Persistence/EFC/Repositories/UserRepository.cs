using backend_carhelp.Iam.Domain.Model.Aggregates;
using backend_carhelp.Iam.Domain.Model.ValueObjects;
using backend_carhelp.Iam.Domain.Repositories;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Configuration;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_carhelp.Iam.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public Task<User?> FindUserByEmailAsync(EmailAddres email)
    {
        return Context.Set<User>().Where(p => p.Email == email).FirstOrDefaultAsync();
    }
    public Task<User?> FindUserByUsernameAsync(string username)
    {
        return Context.Set<User>().Where(p => p.Username == username).FirstOrDefaultAsync();
    }
}