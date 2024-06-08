namespace backend_carhelp.Workshop_management.Domain.Model.ValueObjects;

public record ModelInfo(string Name, string Year)
{
    public ModelInfo() : this(string.Empty, string.Empty){}

    public string FullModelInfo => $"{Name}, {Year}";
}