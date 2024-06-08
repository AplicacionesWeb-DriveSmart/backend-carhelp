namespace backend_carhelp.Iam.Domain.Model.Entities;

public class Workshop
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Aggregates.User User { get; set; }
}