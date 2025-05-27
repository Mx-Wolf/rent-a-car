using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esx.Integration.Configuration;

public static class PropertyConfigureExtensions
{
    public static PropertyBuilder<T> IsMoney<T>(this PropertyBuilder<T> builder)
        => builder.HasPrecision(15, 2);
}