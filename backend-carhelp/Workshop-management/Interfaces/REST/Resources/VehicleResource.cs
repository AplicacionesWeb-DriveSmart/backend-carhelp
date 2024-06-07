namespace backend_carhelp.Workshop_management.Interfaces.REST.Resources;

public record VehicleResource(int Id, string Plate, string Brand, string Model, string Year, string Colour, string ImageUrl, string Mileage);