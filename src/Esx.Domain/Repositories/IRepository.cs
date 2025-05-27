using Esx.Domain.Entities;

namespace Esx.Domain.Repositories;
public interface IRepository<T, in TK> where T : EntityBase<TK> where TK : struct 
{

    Task<IReadOnlyList<T2>> ProjectAsync<T2>(Func<IQueryable<T>, IQueryable<T2>> project,
        CancellationToken cancellationToken);
    Task<T> GetAsync(TK id, CancellationToken  cancellationToken);
    Task<T?> FindAsync(TK id, CancellationToken cancellationToken);
    void Add(T value);
}