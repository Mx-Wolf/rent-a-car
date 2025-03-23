using Esx.Application;

namespace Esx.Integration.CarRenal;

public class UnitOfWork : IUnitOfWork
{
    private readonly CarRentalDbContext carRentalDbContext;
    public UnitOfWork(CarRentalDbContext carRentalDbContext)
    {
        this.carRentalDbContext = carRentalDbContext;
    }

    public Task SaveChangesAsync()
    {
        return carRentalDbContext.SaveChangesAsync();
    }
}
