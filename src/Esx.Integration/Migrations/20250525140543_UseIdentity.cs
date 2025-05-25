using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esx.Integration.Migrations
{
    /// <inheritdoc />
    public partial class UseIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cars");

            migrationBuilder.CreateTable(
                name: "RentRecord",
                schema: "cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriversLicense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VehicleClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarMake = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RentDuration = table.Column<int>(type: "int", nullable: true),
                    PickupLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropoffLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalServices = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRoadReady = table.Column<bool>(type: "bit", nullable: true),
                    TireCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cleanliness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupDamages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupMileage = table.Column<int>(type: "int", nullable: true),
                    PickupFuelLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropoffMileage = table.Column<int>(type: "int", nullable: true),
                    DropoffFuelLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropoffDamages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignedByCustomer = table.Column<bool>(type: "bit", nullable: true),
                    RentalTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceChoice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpsoldServices = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCharges = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true),
                    AdditionalFees = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true),
                    PameymentConfirmation = table.Column<bool>(type: "bit", nullable: true),
                    CustomerExpirience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceImprovementOpportunities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentRecord", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentRecord",
                schema: "cars");
        }
    }
}
