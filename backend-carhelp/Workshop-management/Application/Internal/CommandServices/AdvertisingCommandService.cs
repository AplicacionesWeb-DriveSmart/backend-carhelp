using backend_carhelp.shared.Domain.Repositories;
using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using backend_carhelp.Workshop_management.Domain.Model.Commands;
using backend_carhelp.Workshop_management.Domain.Repositories;
using backend_carhelp.Workshop_management.Domain.Services;

namespace backend_carhelp.Workshop_management.Application.Internal.CommandServices;

public class AdvertisingCommandService(IAdvertisingRepository advertisingRepository, IUnitOfWork unitOfWork): IAdvertisingCommandService
{
    public async Task<Advertising?> Handle(CreateAdvertisingCommand command)
    {
        var advertising = new Advertising(command);
        try
        {
            await advertisingRepository.AddAsync(advertising);
            await unitOfWork.CompleteAsync();
            return advertising;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the advertising: {e.Message}");
            return null;
        }
    }
}
