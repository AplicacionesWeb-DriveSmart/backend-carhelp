using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Model.Queries;
using backend_carhelp.Workshop_management.Domain.Repositories;
using backend_carhelp.Workshop_management.Domain.Services;

namespace backend_carhelp.Workshop_management.Application.Internal.QueryServices;

public class InvoiceQueryService(IInvoiceRepository invoiceQueryService): IInvoiceQueryService
{
    public async Task<IEnumerable<Invoice>> Handle(GetAllInvoicesQuery query)
    {
        return await invoiceQueryService.ListAsync();
    }

    public async Task<Invoice?> Handle(GetInvoiceByIdQuery query)
    {
        return await invoiceQueryService.FindByIdAsync(query.InvoiceId);
    }
}