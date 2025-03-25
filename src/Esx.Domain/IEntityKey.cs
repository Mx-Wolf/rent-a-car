namespace Esx.Domain;

public interface IEntityKey
{
    int Value { get; }

}

public interface IDateTime
{
    DateTime Now { get; }
}