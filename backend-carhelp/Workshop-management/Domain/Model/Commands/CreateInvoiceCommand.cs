namespace backend_carhelp.Workshop_management.Domain.Model.Commands;

public record CreateInvoiceCommand(string Number, string IssueDate, string Total, string Status, string Detail);