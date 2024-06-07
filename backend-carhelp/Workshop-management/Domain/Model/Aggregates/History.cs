using backend_carhelp.Workshop_management.Domain.Model.Commands;

namespace backend_carhelp.Workshop_management.Domain.Model.Aggregates;

public class History
{
    private int Id { get; }
    private string Service_date { get; set; }
    private string Description { get; set; }
    private double Cost { get; set; }
    private int Mileage { get; set; }
    
    public History(string serviceDate, string description, double cost, int mileage)
    {
        Service_date = serviceDate;
        Description = description;
        Cost = cost;
        Mileage = mileage;
    }

    public History(CreateHistoryCommand command) 
        : this(command.Service_date, command.Description, command.Cost, command.Mileage) {}
    
}