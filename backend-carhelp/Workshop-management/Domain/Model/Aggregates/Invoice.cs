using backend_carhelp.Workshop_management.Domain.Model.Commands;

namespace backend_carhelp.Workshop_management.Domain.Model.Aggregates;

public partial class Invoice
{
    public Invoice()
    {
        Number = string.Empty;
        IssueDate = string.Empty;
        Total = string.Empty;
        Status = string.Empty;
        Detail = string.Empty;
        
    }
    public Invoice(string number, string issueDate, string total, string status, string detail) 
    {
        Number = number;
        IssueDate = issueDate;
        Total = total;
        Status = status;
        Detail = detail;
    }
    
    public Invoice(CreateInvoiceCommand command)
        : this(command.Number, command.IssueDate, command.Total, command.Status, command.Detail){}
    
    
    public int Id { get; set; }
    public string Number { get; set; }
    public string IssueDate { get; set; }
    public string Total { get; set; }
    public string Status { get; set; }
    public string Detail { get; set; }
}