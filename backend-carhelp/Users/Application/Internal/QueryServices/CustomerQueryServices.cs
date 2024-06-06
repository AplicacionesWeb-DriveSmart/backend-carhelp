using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.Iam.Domain.Model.Queries;
using backend_carhelp.Iam.Domain.Repositories;
using backend_carhelp.Iam.Domain.Services;

namespace backend_carhelp.Iam.Application.Internal.QueryServices;

public class CustomerQueryServices(ICustomerRepository customerRepository) : ICustomerQueryService
{
    public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query)
    {
        return await customerRepository.ListAsync();
    }
    
    public async Task<Customer?> Handle(GetCustomerByIdQuery query)
    {
        return await customerRepository.FindByIdAsync(query.UserId);
    }
    
}