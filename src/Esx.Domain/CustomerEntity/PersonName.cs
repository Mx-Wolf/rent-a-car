namespace Esx.Domain.CustomerEntity;

public record PersonName(string FirstName, string LastName)
{
    private PersonName():this(string.Empty, string.Empty) { }
    public static readonly PersonName Empty = new PersonName();
}
