namespace backend_carhelp.Workshop_management.Interfaces.REST.Resources;

public record CreateInvoiceResource(string Number, string IssueDate, string Total, string Status, string Detail);
