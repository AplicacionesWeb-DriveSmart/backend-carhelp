using backend_carhelp.Workshop_management.Domain.Model.Commands;
using backend_carhelp.Workshop_management.Domain.Model.ValueObjects;
using Org.BouncyCastle.Asn1.X509;

namespace backend_carhelp.Workshop_management.Domain.Model.Aggregates;

public partial class Vehicle
{
    public Vehicle()
    {
        Plate = string.Empty;
        Brand = string.Empty;
        CarModelInfo = new ModelInfo();
        Colour = string.Empty;
        ImageUrl = string.Empty;
        Mileage = string.Empty;
    }
    public Vehicle(string plate, string brand, string modelName, string modelYear, string colour, string imageUrl, string mileage) 
    {
        Plate = plate;
        Brand = brand;
        CarModelInfo = new ModelInfo(modelName, modelYear);
        Colour = colour;
        ImageUrl = imageUrl;
        Mileage = mileage;
    }

    public Vehicle(CreateVehicleCommand command)
    {
        Plate = command.Plate;
        Brand = command.Brand;
        CarModelInfo = new ModelInfo(command.ModelName, command.ModelYear);
        Colour = command.Colour;
        ImageUrl = command.ImageUrl;
        Mileage = command.Mileage;
    }

    public int Id { get; set; }
    public string Plate { get; set; }
    public string Brand { get; set; }
    public ModelInfo CarModelInfo { get; set; }
    public string Colour { get; set; }
    public string ImageUrl { get; set; }
    public string Mileage { get; set; }

    public string ModelInfoFunc => CarModelInfo.FullModelInfo;

}