namespace backend_carhelp.Workshop_management.Domain.Model.Commands;

public record CreateAdvertasingCommand(string Name, string ImageUrl, string Slogan, string Message, int WorkshopId);