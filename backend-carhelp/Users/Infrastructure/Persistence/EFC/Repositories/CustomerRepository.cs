using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.Iam.Domain.Repositories;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Configuration;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Repositories;

namespace backend_carhelp.Iam.Infrastructure.Persistence.EFC.Repositories;

public class CustomerRepository(AppDbContext context) : BaseRepository<Customer>(context), ICustomerRepository
{
    public async Task DeleteCustomerByIdAsync(int id)
    {
        var customer = await Context.Set<Customer>().FindAsync(id);
        if (customer != null)
        {
            Context.Set<Customer>().Remove(customer);
            await Context.SaveChangesAsync();
        }
    }
}