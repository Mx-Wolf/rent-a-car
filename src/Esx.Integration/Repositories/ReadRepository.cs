
using Esx.Domain.Repositories;

namespace Esx.Integration.Repositories;
public class ReadRepository <T>(MemoryDbContext db) : IReadRepository<T> where T : class
{
    public IQueryable<T> GetAll()
    {
        return db.Set<T>();
    }
}
