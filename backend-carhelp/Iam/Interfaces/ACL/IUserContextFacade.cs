using backend_carhelp.Iam.Domain.Services;

namespace backend_carhelp.Iam.Interfaces.ACL;

public interface IUserContextFacade
{
    Task<int> CreateUser(string email, string password, string firstName, string lastName, string phoneNumber, string street, string number, string city, string postalCode, string country, string username, string imageUrl);
    
    Task<int> FetchUserIdByEmail(string email);
    
    Task<int> FetchUserIdByUsername(string username);
}