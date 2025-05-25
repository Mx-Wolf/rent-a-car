namespace Esx.Domain.Dto;
public record Reservation(
     int Id,
     string? DriverName,
     string? DriversLicense,
     DateTime? DateBirth,
     string? VehicleClass,
     DateTime? DateRent,
     int? RentDuration,
     string? PickupLocation,
     string? DropoffLocation
    );
