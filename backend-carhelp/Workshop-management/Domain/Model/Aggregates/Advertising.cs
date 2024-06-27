using backend_carhelp.Workshop_management.Domain.Model.Commands;

namespace backend_carhelp.Workshop_management.Domain.Model.Aggregates;

public class Advertising
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl{ get; set; }
    public string Slogan{ get; set; }
    public string Message{ get; set; }
    public int WorkshopId{ get; set; }

    public Advertising()
    {
        Name= string.Empty;
        ImageUrl= string.Empty;
        Slogan= string.Empty;
        Message = string.Empty;
        WorkshopId = 0;
    }
    
    public Advertising(string name, string imageUrl, string slogan, string message, int workshopId) {
        Name = name;
        ImageUrl = imageUrl;
        Slogan = slogan;
        Message = message;
        WorkshopId = workshopId;
    }

    public Advertising(CreateAdvertisingCommand createAdvertisingCommand)
    {
        Name = createAdvertisingCommand.Name;
        ImageUrl = createAdvertisingCommand.ImageUrl;
        Slogan = createAdvertisingCommand.Slogan;
        Message = createAdvertisingCommand.Message;
        WorkshopId = createAdvertisingCommand.WorkshopId;
    }
}