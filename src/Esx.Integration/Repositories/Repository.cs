
using Esx.Domain.Entities;
using Esx.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Esx.Integration.Repositories;
public class Repository <T, TK>(MemoryDbContext db) : IRepository<T, TK> where T : EntityBase<TK> where TK: struct, IEquatable<TK>
{

    public async Task<IReadOnlyList<T2>> ProjectAsync<T2>(Func<IQueryable<T>, IQueryable<T2>> project, CancellationToken cancellationToken)
    {
        var q = project(db.Set<T>());
        return await q.ToListAsync(cancellationToken);
    }

    public async Task<T> GetAsync(TK id, CancellationToken cancellationToken)
    {
        var value = await db.Set<T>()
            .Where(e => e.Id.Equals(id))
            .FirstOrDefaultAsync(cancellationToken);
        return value ?? throw new InvalidOperationException();
    }

    public async Task<T?> FindAsync(TK id, CancellationToken cancellationToken)
    {
        return await db.Set<T>()
            .Where(e => e.Id.Equals(id))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public void Add(T value)
    {
        db.Add(value);
    }
}