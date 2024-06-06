using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Domain.Services;

namespace backend_carhelp.Iam.Interfaces.ACL.Services;

public class CustomersContextFacade(ICustomerCommandServcice customerCommandService, ICustomerQueryService customerQueryService) : ICustomerContextFacade
{
    public async Task<int> CreateCustomer(int userId, int id)
    {
        var createCustomerCommand = new CreateCustomerCommand(userId, id);
        var customer = await customerCommandService.Handle(createCustomerCommand);
        return customer?.Id ?? 0;
    }
    
    
}