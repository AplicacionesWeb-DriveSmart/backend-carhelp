namespace backend_carhelp.Workshop_management.Interfaces.REST.Resources;

public record AdvertasingResource(int Id, string Name, string ImageUrl, string Slogan, string Message, int WorkshopId);