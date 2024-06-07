using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Domain.Model.Queries;
using backend_carhelp.Iam.Domain.Model.ValueObjects;
using backend_carhelp.Iam.Domain.Services;

namespace backend_carhelp.Iam.Interfaces.ACL.Services;

public class UsersContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService) : IUserContextFacade
{
    public async Task<int> CreateUser(string email, string password, string firstName, string lastName, string phoneNumber, string street, string number, string city, string postalCode, string country, string username, string imageUrl)
    {
        var createUserCommand = new CreateUserCommand(email, password, firstName, lastName, phoneNumber, street, number, city, postalCode, country, username, imageUrl);
        var user = await userCommandService.Handle(createUserCommand);
        return user?.Id ?? 0;
    }
    
    public async Task<int> FetchUserIdByEmail(string email)
    {
        var getUserByEmailQuery = new GetUserByEmailQuery(new EmailAddres(email));
        var user = await userQueryService.Handle(getUserByEmailQuery);
        return user?.Id ?? 0;
    }
    
    public async Task<int> FetchUserIdByUsername(string username)
    {
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var user = await userQueryService.Handle(getUserByUsernameQuery);
        return user?.Id ?? 0;
    }
}