using Microsoft.EntityFrameworkCore;

namespace Esx.Integration.Audit;

public interface IAuditTrailCollector
{
    void OnSavingChanges(DbContext? dbContext);
    Task OnSavedChanges();
}
