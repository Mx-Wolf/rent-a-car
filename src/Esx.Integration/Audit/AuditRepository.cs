
using Esx.Application.AuditTrail;
using Esx.Domain.AuditTrailEntity;
using Esx.Integration.CarRenal;

namespace Esx.Integration.Audit;

public class AuditRepository : IAuditRepository
{
    private readonly CarRentalDbContext carRentalDbContext;
    public AuditRepository(CarRentalDbContext carRentalDbContext)
    {
        this.carRentalDbContext = carRentalDbContext;
    }

    public void Add(IEnumerable<AuditTrailBase> records)
    {
        carRentalDbContext.Add(records);
    }
}
