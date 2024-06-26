namespace backend_carhelp.Workshop_management.Interfaces.REST.Resources;

public record CreateProductResource(string Name, int Quantity, double Price, string ImageUrl, int WorkshopId);