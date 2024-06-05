namespace backend_carhelp.shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}