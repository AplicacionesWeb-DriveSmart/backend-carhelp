using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Model.Commands;

namespace backend_carhelp.Workshop_management.Domain.Services;

public interface IAdvertasingCommandService
{
    Task<Advertasing?> Handle(CreateAdvertasingCommand command);
}