namespace Esx.Domain.Dto;
public class Reservation
{
    public string? DriverName { get; set; }
    public string? DriversLicense { get; set; }
    public DateTime? DateBirth { get; set; }
    public string? VehicleClass { get; set; }
    public DateTime? DateRent { get; set; }
    public int? RentDuration { get; set; }
    public string? PickupLocation { get; set; }
    public string? DropoffLocation { get; set; }
}
