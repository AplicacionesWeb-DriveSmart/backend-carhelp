namespace backend_carhelp.Iam.Domain.Model.ValueObjects;

public record EmailAddres(string Address)
{
    public EmailAddres() : this(string.Empty){}
}