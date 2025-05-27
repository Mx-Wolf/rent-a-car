namespace Esx.Controllers.Bodies;
public record Reservation(
     string? DriverName,
     string? DriversLicense,
     DateTime? DateBirth,
     string? VehicleClass,
     DateTime? DateRent,
     int? RentDuration,
     string? PickupLocation,
     string? DropoffLocation
    );