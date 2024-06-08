using backend_carhelp.shared.Infrastructure.Persistence.EFC.Configuration;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Repositories;
using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_carhelp.Workshop_management.Infrastructure.Persistence.EFC.Repositories;

public class InvoiceRepository(AppDbContext context): BaseRepository<Invoice>(context), IInvoiceRepository
{

    public async Task<Invoice> GetByIdAsync(int id)
    {
        return await context.Invoices.FindAsync(id);
    }
}