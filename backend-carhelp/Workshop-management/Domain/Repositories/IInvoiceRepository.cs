using backend_carhelp.shared.Domain.Repositories;
using backend_carhelp.Workshop_management.Domain.Model.Aggregates;

namespace backend_carhelp.Workshop_management.Domain.Repositories;

public interface IInvoiceRepository : IBaseRepository<Invoice>
{
    Task<Invoice> GetByIdAsync(int id);
}