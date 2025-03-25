
using Esx.Application.AuditTrail;
using Esx.Domain;
using Esx.Domain.AuditTrailEntity;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Esx.Integration.Audit;

public class AuditTrailCollector : IAuditTrailCollector
{
    private readonly IMediator mediator;
    private readonly IChangeTrackerHelper trackerHelper;
    private readonly IUserNameService userNameService;
    private readonly IDateTime dateTime;
    private readonly IObjectNameReader objectNameReader;
    private readonly ICatetoryReader categoryReader;
    private readonly List<AuditTrailBufferRecord> current = new();
    public AuditTrailCollector(
        IMediator mediator,
        IChangeTrackerHelper trackerHelper,
        IUserNameService userNameService,
        IDateTime dateTime,
        IObjectNameReader objectNameReader,
        ICatetoryReader categoryReader)
    {
        this.mediator = mediator;
        this.trackerHelper = trackerHelper;
        this.userNameService = userNameService;
        this.dateTime = dateTime;
        this.objectNameReader = objectNameReader;
        this.categoryReader = categoryReader;
    }

    public async Task OnSavedChanges()
    {
        await mediator.Publish(PrepareNotification());
    }

    private AuditTrailNotification PrepareNotification()
    {
        return new AuditTrailNotification
        {
            AuditRecords = FromRecords(),
        };
    }

    private IEnumerable<AuditTrailBase> FromRecords()
    {
        var result = current.Where(d => d.Entity != null).Select(c =>
        {
            //simple
            return new AuditTrail
            {
                Record = PrepareRecord(c)
            };
        }).ToArray();
        current.Clear();
        return result;
    }

    private AuditRecord PrepareRecord(AuditTrailBufferRecord c)
    {
        var ob = objectNameReader.ReadObjectName(c.Entity!);
        return new AuditRecord
        {
            Category = categoryReader.GetCatetoryName(c),
            Changes = PrepareChanges(c),
            CompletedBy = userNameService.GetUserInfo(),
            DateCompleted = dateTime.Now,
            ObjectId = ob.ObjectId,
            ObjectName = ob.Name
        };
    }

    private static List<ChangeInfo> PrepareChanges(AuditTrailBufferRecord c)
    {
        return c.ChangesByField.Select(p => new ChangeInfo(
            Action: c.State.ToString(),
            Field: p.Key,
            NewValue: p.Value.Current,
            OldValue: p.Value.Original
            )).ToList();
    }

    public void OnSavingChanges(DbContext? dbContext)
    {

        current.Clear();
        if (dbContext == null) return;
        current.AddRange(
            dbContext.ChangeTracker.Entries().Select(r =>
            {
                return new AuditTrailBufferRecord
                {
                    State = r.State,
                    Entity = r.Entity as EntityBase,
                    ChangesByField = trackerHelper.GetChanges(r.OriginalValues, r.CurrentValues),
                };
            }));
    }

}
