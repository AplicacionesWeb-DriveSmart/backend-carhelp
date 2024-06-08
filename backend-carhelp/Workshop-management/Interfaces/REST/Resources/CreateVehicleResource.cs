namespace backend_carhelp.Workshop_management.Interfaces.REST.Resources;

public record CreateVehicleResource(string Plate, string Brand, string ModelName, string ModelYear, string Colour, string ImageUrl, string Mileage);