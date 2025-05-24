namespace Esx.Domain.Repositories;
public interface IReadRepository<out T> where T : class
{
    IQueryable<T> GetAll();
}
