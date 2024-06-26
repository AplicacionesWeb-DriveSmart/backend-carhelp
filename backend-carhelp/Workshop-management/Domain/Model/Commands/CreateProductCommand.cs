namespace backend_carhelp.Workshop_management.Domain.Model.Commands;

public record CreateProductCommand(string Name, int Quantity, double Price, string ImageUrl, int WorkshopId);