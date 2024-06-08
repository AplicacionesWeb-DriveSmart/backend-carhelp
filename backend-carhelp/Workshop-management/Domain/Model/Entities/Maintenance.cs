using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.Workshop_management.Domain.Model.Aggregates;

namespace backend_carhelp.Workshop_management.Domain.Model.Entities;

public class Maintenance
{
    public int Id { get; }
    public string Status { get; private set; }
    public string LastVisitDate { get; private set; }
    public string Comment { get; private set; }
    public Invoice Invoice { get; set; }
    public int InvoiceId { get; private set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; private set; }
    public Workshop Workshop { get; set; }
    public int WorkshopId { get; private set; }
    public Vehicle Vehicle { get; set; }
    public int VehicleId { get; private set; }

    public Maintenance(string status, string lastVisitDate, string comment, int invoiceId, int customerId, int workshopId, int vehicleId)
    {
        Status = status;
        LastVisitDate = lastVisitDate;
        Comment = comment;
        InvoiceId = invoiceId;
        CustomerId = customerId;
        WorkshopId = workshopId;
        VehicleId = vehicleId;
    }
    
    public Maintenance(){}
    
    public Maintenance(CreateMaintenanceCommand command) 
        : this(command.status, command.lastVisitDate, command.comment, command.invoiceId,command.customerId,command.workshopId,command.vehicleId){}
    

}