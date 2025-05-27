namespace Esx.Domain.Entities;

public record struct RentRecordId(int Value)
{
    public static implicit operator int(RentRecordId rid) => rid.Value;
    public static explicit operator RentRecordId(int id) => new(id);
};
