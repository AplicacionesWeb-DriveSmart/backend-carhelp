using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Model.Queries;

namespace backend_carhelp.Workshop_management.Domain.Services;

public interface IInvoiceQueryService
{
    Task<IEnumerable<Invoice>> Handle(GetAllInvoicesQuery query);
    Task<Invoice?> Handle(GetInvoiceByIdQuery query);
}