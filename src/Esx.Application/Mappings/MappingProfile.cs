using AutoMapper;

using Esx.Domain.Dto;
using Esx.Domain.Entities;

namespace Esx.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RentRecord, Esx.Domain.Dto.Reservation>();
        CreateMap<RentRecordId, int>().ConvertUsing(e => e.Value);
    }
}
