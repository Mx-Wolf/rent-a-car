namespace Esx.Domain;

public interface IEntityRepository<TEntity, TEntityId>
    where TEntity : EntityBase<TEntityId>
    where TEntityId : struct, IEquatable<TEntityId>, IComparable<TEntityId>, IEqualityOperators<TEntityId, TEntityId, bool>, IComparisonOperators<TEntityId, TEntityId, bool>
{
    Task<TEntity?> Find(TEntityId entityId);
    void Add(TEntity entity);
    void Delete(TEntity entity);
    Task Delete(TEntityId id);
}