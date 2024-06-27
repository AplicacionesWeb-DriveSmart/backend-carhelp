namespace backend_carhelp.Workshop_management.Interfaces.REST.Resources;

public record CreateAdvertisingResource(string Name, string ImageUrl, string Slogan, string Message, int WorkshopId);