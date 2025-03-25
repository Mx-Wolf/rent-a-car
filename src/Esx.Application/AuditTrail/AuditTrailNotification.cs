
using Esx.Domain.AuditTrailEntity;

using MediatR;

namespace Esx.Application.AuditTrail;
public class AuditTrailNotification : INotification
{
    public required IEnumerable<AuditTrailBase> AuditRecords { get; init; }
}
public class AuditTrailNotificationHandler : INotificationHandler<AuditTrailNotification>
{
    private readonly IAuditRepository auditRepository;
    private readonly IUnitOfWork unitOfWork;
    public AuditTrailNotificationHandler(
        IAuditRepository auditRepository, 
        IUnitOfWork unitOfWork)
    {
        this.auditRepository = auditRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(AuditTrailNotification notification, CancellationToken cancellationToken)
    {
        auditRepository.Add(notification.AuditRecords);
        await unitOfWork.SaveChangesAsync();
    }
}
