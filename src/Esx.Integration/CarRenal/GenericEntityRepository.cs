
using System.Numerics;

using Esx.Domain;

using Microsoft.EntityFrameworkCore;

namespace Esx.Integration.CarRenal;

public class GenericEntityRepository<TEntity, TEntityId>
    : IEntityRepository<TEntity, TEntityId>
    where TEntity : EntityBase<TEntityId>
    where TEntityId : struct, IEntityKey, IEquatable<TEntityId>, IComparable<TEntityId>, IEqualityOperators<TEntityId, TEntityId, bool>, IComparisonOperators<TEntityId, TEntityId, bool>
{
    private readonly DbSet<TEntity> entities;
    public GenericEntityRepository(CarRentalDbContext db)
    {
        entities = db.Set<TEntity>();
    }
    public void Add(TEntity entity)
    {
        entities.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        entities.Remove(entity);
    }

    public async Task Delete(TEntityId id)
    {
        var entity = await Find(id) ?? throw new KeyNotFoundException();
        Delete(entity);
    }
    public record struct X(int Value);
    public async Task<TEntity?> Find(TEntityId entityId)
    {
        ((IEquatable<TEntityId>)entityId).Equals(entityId);
        int i = entityId.Value;
        return await entities.FirstOrDefaultAsync(e => e.Id.Value.Equals(i));
    }
}