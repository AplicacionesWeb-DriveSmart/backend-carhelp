namespace backend_carhelp.Iam.Domain.Model.Commands;

public record CreateUserCommand(string FirstName, string LastName, string Email, string PhoneNumber, string Street, string Number, string City, string PostalCode, string Country, string Password, string Username, string ImageUrl);