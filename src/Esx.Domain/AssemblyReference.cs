using System.Reflection;

using StronglyTypedIds;

[assembly: StronglyTypedIdDefaults(Template.Int)]

namespace Esx.Domain;
public static class DomainAssembly
{
    public static Assembly Instance { get; } = typeof(DomainAssembly).Assembly;
}
