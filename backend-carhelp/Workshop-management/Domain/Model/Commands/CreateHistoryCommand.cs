namespace backend_carhelp.Workshop_management.Domain.Model.Commands;

public record CreateHistoryCommand(string Service_date, string Description, double Cost, int Mileage);