using AutoMapper;

namespace Esx.Controllers.Bodies;

public static class MapperExtensions
{
    public static TDst MapWithId<TDst>(this IMapper mapper, WithId id, object body)
    {
        var result = mapper.Map<TDst>(id);
        return mapper.Map(body, result);
    }
}