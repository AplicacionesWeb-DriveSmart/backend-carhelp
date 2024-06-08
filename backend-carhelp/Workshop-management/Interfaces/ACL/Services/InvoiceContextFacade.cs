using backend_carhelp.Workshop_management.Domain.Model.Commands;
using backend_carhelp.Workshop_management.Domain.Services;

namespace backend_carhelp.Workshop_management.Interfaces.ACL.Services;

public  class InvoiceContextFacade(IInvoiceCommandService invoiceCommandService, IInvoiceQueryService invoiceQueryService) : IInvoiceFacade
{
    public async Task<int> CreateInvoice(string Number, string issueDate, string Total, string Status, string Detail)
    {
        var createInvoiceCommand = new CreateInvoiceCommand(Number, issueDate, Total, Status, Detail);
        var invoice = await invoiceCommandService.Handle(createInvoiceCommand);
        return invoice?.Id ?? 0;
    }
}