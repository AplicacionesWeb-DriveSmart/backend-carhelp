namespace backend_carhelp.Workshop_management.Interfaces.REST.Resources;

public record ProductResource(int Id, string Name, int Quantity, double Price, string ImageUrl, int WorkshopId);