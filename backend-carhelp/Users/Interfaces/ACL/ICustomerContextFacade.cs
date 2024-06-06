namespace backend_carhelp.Iam.Interfaces.ACL;

public interface ICustomerContextFacade
{
    Task<int> CreateCustomer(int UserId, int Id);
}