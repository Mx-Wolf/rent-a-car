namespace Esx.Domain.Entities;

public record struct RentRecordId(int Value)
{
    public static implicit operator int(RentRecordId rid) => rid.Value;
};
