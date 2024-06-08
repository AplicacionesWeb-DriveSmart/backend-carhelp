using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Domain.Model.Entities;

namespace backend_carhelp.Iam.Domain.Services;

public interface IWorkshopCommandService
{
    Task<Workshop?> Handle(CreateWorkshopCommand command);
    
    Task Handle(DeleteWorkshopCommand command);
}