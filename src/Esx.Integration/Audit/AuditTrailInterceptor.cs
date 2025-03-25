using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Esx.Integration.Audit;

public class AuditTrailInterceptor : SaveChangesInterceptor
{
    private readonly IAuditTrailCollector trailCollector;

    public AuditTrailInterceptor(IAuditTrailCollector trailCollector)
    {
        this.trailCollector = trailCollector;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        trailCollector.OnSavingChanges(eventData.Context);
        return base.SavingChanges(eventData, result);
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        trailCollector.OnSavingChanges(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        var t = trailCollector.OnSavedChanges();
        t.Wait();//!!!
        return base.SavedChanges(eventData, result);
    }
    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        await trailCollector.OnSavedChanges();
        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }
}
