namespace backend_carhelp.Iam.Interfaces.REST.Resources;

public record CreateUserResource(string Email, string Password, string FirstName, string LastName, string PhoneNumber, string Street, string Number, string City, string PostalCode, string Country, string Username, string ImageUrl);