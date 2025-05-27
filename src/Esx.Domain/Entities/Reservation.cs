namespace Esx.Domain.Entities;

public class Reservation : EntityBase<RentRecordId>
{
    public required string PickupLocation { get; set; }
}