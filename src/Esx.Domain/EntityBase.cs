using System.Numerics;

namespace Esx.Domain;
public abstract class EntityBase<TEntityId> where TEntityId
    : struct,
    IEquatable<TEntityId>,
    IComparable<TEntityId>,
    IComparisonOperators<TEntityId, TEntityId, bool>,
    IEqualityOperators<TEntityId, TEntityId, bool>
{
    public TEntityId Id { get; private set; }
    protected EntityBase(TEntityId id) { Id = id; }
}
