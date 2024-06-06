using backend_carhelp.Iam.Domain.Model.Aggregates;
using backend_carhelp.Iam.Domain.Model.Queries;
using backend_carhelp.Iam.Domain.Repositories;
using backend_carhelp.Iam.Domain.Services;

namespace backend_carhelp.Iam.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
    
    public async Task<User?> Handle(GetUserByEmailQuery query)
    {
        return await userRepository.FindUserByEmailAsync(query.Email);
    }
    
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }
    
    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindUserByUsernameAsync(query.Username);
    }
}