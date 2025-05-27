using AutoMapper;

namespace Esx.Controllers.Bodies;

public static class MapperExtensions
{
    public static TDest MapWithId<TDest>(this IMapper mapper, WithId id, object body)
    {
        var result = mapper.Map<TDest>(id);
        return mapper.Map(body, result);
    }
}