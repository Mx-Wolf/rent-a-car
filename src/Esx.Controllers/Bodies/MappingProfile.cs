using AutoMapper;

namespace Esx.Controllers.Bodies;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<(int, Reservation), Esx.Domain.Dto.Reservation>()
            .ConstructUsing(e=>new Domain.Dto.Reservation(
                e.Item1,
                e.Item2.DriverName,
                e.Item2.DriversLicense,
                e.Item2.DateBirth,
                e.Item2.VehicleClass,
                e.Item2.DateRent,
                e.Item2.RentDuration,
                e.Item2.PickupLocation,
                e.Item2.DropoffLocation));
    }
}