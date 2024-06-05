using backend_carhelp.Iam.Domain.Model.Aggregates;
using backend_carhelp.Iam.Domain.Model.ValueObjects;
using backend_carhelp.shared.Domain.Repositories;

namespace backend_carhelp.Iam.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> FindUserByEmailAsync(EmailAddres email);
    Task<User> FindUserByUsernameAsync(string username);
    Task DeleteUserByIdAsync(int id);
}