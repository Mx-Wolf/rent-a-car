namespace Esx.Domain.CarEntity;
public class Car : EntityBase<CarId>
{
    public required string Model { get; init; }
    public required string LicensePlate { get; init; }
    public decimal Pice { get; private set; }
    public CarStatus Status { get; private set; }
}