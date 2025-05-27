namespace Esx.Domain.Entities;

public class RentRecord: EntityBase<RentRecordId> 
{ 
    public required string DriverName { get; set; }
    public string? DriversLicense { get; set; }
    public DateTime? DateBirth { get; set; }
    public string? VehicleClass { get; set; }
    public string? CarMake { get; set; }
    public string? CarModel { get; set; }
    public string? CarYear { get; set; }
    public string? CarLicensePlate { get; set; }
    public DateTime? DateRent { get; set; }
    public int? RentDuration { get; set; }
    public string? PickupLocation { get; set; }
    public string? DropoffLocation { get; set; }
    public string? AdditionalServices { get; set; }
    public bool? IsRoadReady { get; set; }
    public string? TireCondition { get; set; }
    public string? Cleanliness { get; set; }
    public string? PickupDamages { get; set; }
    public int? PickupMileage { get; set; }
    public string? PickupFuelLevel { get; set; }
    public int? DropoffMileage { get; set; }
    public string? DropoffFuelLevel { get; set; }
    public string? DropoffDamages { get; set; }
    public bool? SignedByCustomer { get; set; }
    public string? RentalTerms { get; set; }
    public string? InsuranceChoice { get; set; }
    public string? UpsoldServices { get; set; }
    public decimal? TotalCharges { get; set; }
    public decimal? AdditionalFees { get; set; }
    public bool PaymentConfirmation { get; set; }
    public string? CustomerExperience { get; set; }
    public string? ServiceImprovementOpportunities { get; set; }



}