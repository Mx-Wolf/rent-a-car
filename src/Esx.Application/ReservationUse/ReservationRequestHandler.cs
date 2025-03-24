using Esx.Domain;
using Esx.Domain.AuditTrailEntity;
using Esx.Domain.CustomerEntity;
using Esx.Domain.ReservationEntity;

namespace Esx.Application.ReservationUse;

public class ReservationRequestHandler : IReservationRequestHandler
{
    private readonly IEntityRepository<Reservation, ReservationId> reservations;
    private readonly IEntityRepository<Customer, CustomerId> customers;
    private readonly IEntityRepository<AuditTrial, AuditTrialId> auditTrials;
    private readonly IEntityRepository<AuditTrail<DocumentExtra>, AuditTrialId> documentTrail;
    private readonly IUnitOfWork unitOfWork;

    public ReservationRequestHandler(
        IEntityRepository<Reservation, ReservationId> reservations,
        IEntityRepository<Customer, CustomerId> customers,
        IUnitOfWork unitOfWork,
        IEntityRepository<AuditTrial, AuditTrialId> auditTrials,
        IEntityRepository<AuditTrail<DocumentExtra>, AuditTrialId> documentTrail)
    {
        this.reservations = reservations;
        this.customers = customers;
        this.unitOfWork = unitOfWork;
        this.auditTrials = auditTrials;
        this.documentTrail = documentTrail;
    }

    public async Task MakeAdHocReservation(MakeAdHocReservationRequest request)
    {
        var customer = new Customer(
            new PersonName(request.FirstName, request.LastName),
            Customer.DriverLicenseNull,
            PaymentInfo.Null
            );
        customers.Add(customer);

        await unitOfWork.SaveChangesAsync();

        var reservation = new Reservation(
            request.CarId,
            customer.Id,
            request.DateStart,
            request.DateEnd
            );
        reservations.Add(reservation);

        await unitOfWork.SaveChangesAsync();

        var audit = new AuditTrial
        {
            Record = new AuditRecord
            {
                Category = "Test1",
                Changes = [new ChangeInfo("test action", "test field", "42", "-")],
                CompletedBy= new UserInfo("mr x", "mrx@example.com"),
                DateCompleted = DateTime.UtcNow,
                ObjectId =  42,
                ObjectName = "foo",
            }
        };
        auditTrials.Add(audit);

        var docTrailRecord = new AuditTrail<DocumentExtra>
        {
            Extra = new DocumentExtra { Document=73 },
            Record = new AuditRecord
            {
                Category = "Test1",
                Changes = [new ChangeInfo("test action", "test field", "42", "-")],
                CompletedBy = new UserInfo("mr x", "mrx@example.com"),
                DateCompleted = DateTime.UtcNow,
                ObjectId = 42,
                ObjectName = "foo",
            }
        };

        documentTrail.Add(docTrailRecord);

        await unitOfWork.SaveChangesAsync();
    }
}
