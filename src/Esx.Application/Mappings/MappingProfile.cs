using AutoMapper;

using Esx.Domain.Dto;
using Esx.Domain.Entities;

namespace Esx.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RentRecord, Reservation>();
    }
}
