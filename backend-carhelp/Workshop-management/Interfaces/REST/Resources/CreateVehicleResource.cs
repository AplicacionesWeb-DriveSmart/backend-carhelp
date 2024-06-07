namespace backend_carhelp.Workshop_management.Interfaces.REST.Resources;

public record CreateVehicleResource(int Id, string Plate, string Brand, string Model, string Year, string Colour, string ImageUrl, string Mileage);