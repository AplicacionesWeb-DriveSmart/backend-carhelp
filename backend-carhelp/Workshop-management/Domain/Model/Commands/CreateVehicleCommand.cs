namespace backend_carhelp.Workshop_management.Domain.Model.Commands;

public record CreateVehicleCommand(string Plate, string Brand, string Model,string Year, string Color, string ImageUrl, string Mileage);