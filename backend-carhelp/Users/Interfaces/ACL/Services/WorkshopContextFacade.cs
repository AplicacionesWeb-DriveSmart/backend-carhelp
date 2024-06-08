using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Domain.Services;

namespace backend_carhelp.Iam.Interfaces.ACL.Services;

public class WorkshopContextFacade(IWorkshopCommandService workshoprCommandService, IWorkshopQueryService workshopQueryService) : IWorkshopContextFacade
{
    public async Task<int> CreateWorkshop(int userId, int id)
    {
        var createCustomerCommand = new CreateWorkshopCommand(userId);
        var customer = await workshoprCommandService.Handle(createCustomerCommand);
        return customer?.Id ?? 0;
    }
}