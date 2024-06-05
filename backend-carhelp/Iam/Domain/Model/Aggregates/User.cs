using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Domain.Model.ValueObjects;

namespace backend_carhelp.Iam.Domain.Model.Aggregates;

public partial class User
{
    public User()
    {
        Name = new PersonName();
        Email = new EmailAddres();
        Address = new StreetAddress();
        PhoneNumber = string.Empty;
        Username = string.Empty;
        Password = string.Empty;
        ImageUrl = string.Empty;
    }
    
    public User(string firstName, string lastName, string email, string street, string number, string city, string postalCode, string country, string phoneNumber, string username, string password, string imageUrl)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddres(email);
        Address = new StreetAddress(street, number, city, postalCode, country);
        PhoneNumber = phoneNumber;
        Username = username;
        Password = password;
        ImageUrl = imageUrl;
    }

    public User(CreateUserCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddres(command.Email);
        Address = new StreetAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);
        PhoneNumber = command.PhoneNumber;
        Username = command.Username;
        Password = command.Password;
        ImageUrl = command.ImageUrl;
    }
    
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddres Email { get; private set; }
    public StreetAddress Address { get; private set; }
    
    public string Username { get; }
    public string Password { get; }
    public string PhoneNumber { get; }
    public string ImageUrl { get; private set; }
    
    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    public string StreetAddress => Address.FullAddress;
    
}