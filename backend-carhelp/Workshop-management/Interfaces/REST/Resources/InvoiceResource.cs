namespace backend_carhelp.Workshop_management.Interfaces.REST.Resources;

public record InvoiceResource(int Id, string Number, string IssueDate, string Total, string Status, string Detail);
