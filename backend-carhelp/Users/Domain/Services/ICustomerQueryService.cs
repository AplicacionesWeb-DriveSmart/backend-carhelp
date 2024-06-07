using backend_carhelp.Iam.Domain.Model.Aggregates;
using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.Iam.Domain.Model.Queries;

namespace backend_carhelp.Iam.Domain.Services;

public interface ICustomerQueryService
{
    Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query);
    Task<Customer?> Handle(GetCustomerByIdQuery query);
}