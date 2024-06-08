namespace backend_carhelp.Iam.Interfaces.ACL.Services;

public interface IWorkshopContextFacade
{
    Task<int> CreateWorkshop(int UserId, int Id);
}