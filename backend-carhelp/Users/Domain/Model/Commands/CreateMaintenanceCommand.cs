namespace backend_carhelp.Iam.Domain.Model.Commands;

public record CreateMaintenanceCommand(string status, string lastVisitDate, string comment, int invoiceId, int customerId, int workshopId, int vehicleId);