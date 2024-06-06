using backend_carhelp.Iam.Domain.Model.Aggregates;
using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.shared.Domain.Repositories;

namespace backend_carhelp.Iam.Domain.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    Task DeleteCustomerByIdAsync(int id);
}