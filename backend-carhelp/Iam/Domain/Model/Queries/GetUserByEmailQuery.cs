using backend_carhelp.Iam.Domain.Model.ValueObjects;

namespace backend_carhelp.Iam.Domain.Model.Queries;

public record GetUserByEmailQuery(EmailAddres Email);
