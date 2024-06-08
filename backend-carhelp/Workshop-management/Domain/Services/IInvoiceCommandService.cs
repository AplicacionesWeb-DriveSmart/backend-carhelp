using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Model.Commands;

namespace backend_carhelp.Workshop_management.Domain.Services;

public interface IInvoiceCommandService
{
    Task<Invoice?> Handle(CreateInvoiceCommand command);
    Task Handle(DeleteInvoiceCommand command);
}