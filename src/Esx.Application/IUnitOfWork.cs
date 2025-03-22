namespace Esx.Application
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}
