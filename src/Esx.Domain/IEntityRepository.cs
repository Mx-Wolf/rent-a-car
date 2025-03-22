namespace Esx.Domain;

public interface IEntityRepository<TEntity, TEntityId> where TEntity: EntityBase<TEntityId> where TEntityId: struct
{
    Task<TEntity> Find(TEntityId entityId);
    void Add(TEntity entity);
    void Delete(TEntity entity);
    Task Delete(TEntityId id);
}