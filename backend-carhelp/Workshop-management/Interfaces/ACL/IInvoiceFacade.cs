using backend_carhelp.Workshop_management.Domain.Services;

namespace backend_carhelp.Workshop_management.Interfaces.ACL;

public interface IInvoiceFacade
{
    Task<int> CreateInvoice(string number, string issueDate, string total,string status, string detail);   
}