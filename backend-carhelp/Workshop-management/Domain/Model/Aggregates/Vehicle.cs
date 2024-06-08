using backend_carhelp.Workshop_management.Domain.Model.Commands;
using Org.BouncyCastle.Asn1.X509;

namespace backend_carhelp.Workshop_management.Domain.Model.Aggregates;

public partial class Vehicle
{
    public Vehicle(string plate, string brand, string model, string year, string colour, string imageUrl, string mileage) 
    {
        Plate = plate;
        Brand = brand;
        Model = model;
        Year = year;
        Colour = colour;
        ImageUrl = imageUrl;
        Mileage = mileage;
    }
    
    public Vehicle(CreateVehicleCommand command)
        : this(command.Plate, command.Brand, command.Model, command.Year, command.Colour, command.ImageUrl, command.Mileage){}

    public int Id { get; set; }
    public string Plate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public string Colour { get; set; }
    public string ImageUrl { get; set; }
    public string Mileage { get; set; }
    
}