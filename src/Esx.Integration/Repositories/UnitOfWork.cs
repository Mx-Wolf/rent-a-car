using Esx.Domain.Repositories;

namespace Esx.Integration.Repositories;

public class UnitOfWork(MemoryDbContext db):IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await db.SaveChangesAsync(cancellationToken);
    }
}