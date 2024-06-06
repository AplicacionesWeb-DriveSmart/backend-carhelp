
namespace backend_carhelp.Iam.Domain.Model.Entities;

public class Customer
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Aggregates.User User { get; set; }
    
}
