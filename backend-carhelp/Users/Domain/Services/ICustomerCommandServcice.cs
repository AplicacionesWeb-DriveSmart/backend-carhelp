using backend_carhelp.Iam.Domain.Model.Aggregates;
using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Domain.Model.Entities;

namespace backend_carhelp.Iam.Domain.Services;

public interface ICustomerCommandServcice
{
    Task<Customer?> Handle(CreateCustomerCommand command);
    
    Task Handle(DeleteCustomerCommand command);
}